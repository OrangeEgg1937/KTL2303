using Inworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMurderScenario
{
    None,
    Samantha,
    Mark,
    Lisa,
}

public class GameProcesser : MonoBehaviour
{
    [Header("Environment Objects")]
    [SerializeField] private GameObject[] _environmentObjects;

    [Header("NPC")]
    [SerializeField] private GameObject m_objectSamantha;
    [SerializeField] private GameObject m_objectMark;
    [SerializeField] private GameObject m_objectLisa;
    [SerializeField] private string triggerName;

    [Header("Current Murder Scenario")]
    [SerializeField] private GameMurderScenario _murder;
    [SerializeField] private GameObject _weaponLocation;

    [Header("Murder Weapon")]
    [SerializeField] private Item _Samantha_murderWeapon;
    [SerializeField] private Item _Mark_murderWeapon;
    [SerializeField] private Item _Lisa_murderWeapon;

    [Header("Dialog Control")]
    [SerializeField] private AIChatWindows _SamanthaChatBox;
    [SerializeField] private AIChatWindows _MarkChatBox;
    [SerializeField] private AIChatWindows _LisaChatBox;

    private InworldCharacter m_Samantha;
    private InworldCharacter m_Mark;
    private InworldCharacter m_Lisa;

    private void Awake()
    {
        m_Samantha = m_objectSamantha.GetComponent<InworldCharacter>();
        m_Mark     = m_objectMark.GetComponent<InworldCharacter>();
        m_Lisa     = m_objectLisa.GetComponent<InworldCharacter>();

        // Choose the game murder
        _murder = (GameMurderScenario) Random.Range(1, 3);

        // Choose the weapon location
        _weaponLocation = _environmentObjects[Random.Range(0, _environmentObjects.Length)];

        // Make the trigger name
        switch (_murder)
        {
            case GameMurderScenario.None: break;
            case GameMurderScenario.Lisa:
                triggerName = "after_lunch_a"; break;
            case GameMurderScenario.Mark:
                triggerName = "after_lunch_b"; break;
            case GameMurderScenario.Samantha:
                triggerName = "after_lunch_c"; break;
            default: break;
        }

        // Print the information
        print("\n==========================\n" +
               " INITIAL GAME SCENARIO\n" +
      "==========================");
        print("\n==========================\n" +
              "_murder is " + _murder + "\n" +
              "_weaponLocation is " + _weaponLocation.name + "\n" +
              "==========================");
    }

    public void GenerateMurderWeapon()
    {
        InteractableObject placer = _weaponLocation.GetComponent<InteractableObject>();
        switch ( _murder )
        {
            case GameMurderScenario.None: break; 
            case GameMurderScenario.Lisa:
                placer.PutWeapon(_Lisa_murderWeapon); break;
            case GameMurderScenario.Mark:
                placer.PutWeapon(_Mark_murderWeapon); break;
            case GameMurderScenario.Samantha:
                placer.PutWeapon(_Samantha_murderWeapon); break;
            default: break;
        }
    }

    public void ProcessPostMurderEvent()
    {
        // Adding a line to the NPC dialog
        _SamanthaChatBox.CreatePlayerMessageBox("In the investigation stage...");
        _MarkChatBox.CreatePlayerMessageBox("In the investigation stage...");
        _LisaChatBox.CreatePlayerMessageBox("In the investigation stage...");

        // Send the trigger to the NPC
        m_Samantha.SendTrigger(triggerName);
        m_Mark.SendTrigger(triggerName);
        m_Lisa.SendTrigger(triggerName);

        // Change the NPC to InvestigationStage
        NPC npcL = m_objectLisa.GetComponent<NPC>();
        NPC npcM = m_objectMark.GetComponent<NPC>();
        NPC npcS = m_objectSamantha.GetComponent<NPC>();

        npcL.isInvestigationStage = true;
        npcM.isInvestigationStage = true;
        npcS.isInvestigationStage = true;

    }

    public void OnTriggerReceived(string character, string trigger)
    {
        print("I received trigger from " + character);
        print(trigger);

        if (trigger == "hide_weapon_knife")
        {
            NPC npc = m_objectLisa.GetComponent<NPC>();
            npc.SetDestination(_weaponLocation.transform);
        }

        if (trigger == "hide_weapon_golfclub")
        {
            NPC npc = m_objectMark.GetComponent<NPC>();
            npc.SetDestination(_weaponLocation.transform);
        }

        if (trigger == "hide_weapon_poisonedwine")
        {
            NPC npc = m_objectSamantha.GetComponent<NPC>();
            npc.SetDestination(_weaponLocation.transform);
        }
    }


}
