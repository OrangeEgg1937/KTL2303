using Inworld;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameMurderScenario
{
    None,
    Samantha,
    Mark,
    Lisa,
}

public enum EndGameStatus
{
    None,
    Win,
    Lose,
    Half,
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

    [Header("End game UI elements")]
    [SerializeField] private TextMeshProUGUI userSelectedMurder;
    [SerializeField] private TextMeshProUGUI userSelectedWeapon;
    [SerializeField] private GameObject EndGameUI;
    [SerializeField] private TextMeshProUGUI EndGameUIText;

    [Header("DEBUG")]
    [SerializeField] private float distance;
    [SerializeField] private EndGameStatus EndGameProcess;

    private InworldCharacter m_Samantha;
    private InworldCharacter m_Mark;
    private InworldCharacter m_Lisa;

    private void Update()
    {
        // Check the murder and _weaponLocation distance
        checkMurderAndWeaponLocationDistance();
    }

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

    private void checkMurderAndWeaponLocationDistance()
    {
        if (_weaponLocation == null) { return; }

        // murder game object transform
        Transform murder;

        // Set the NPC
        switch (_murder)
        {
            case GameMurderScenario.None: return;
            case GameMurderScenario.Lisa:
                murder = m_objectLisa.GetComponent<Transform>(); break;
            case GameMurderScenario.Mark:
                murder = m_objectMark.GetComponent<Transform>(); break;
            case GameMurderScenario.Samantha:
                murder = m_objectSamantha.GetComponent<Transform>(); break;
                default : return;
        }

        distance = Vector3.Distance(_weaponLocation.transform.position, murder.position);
        distance = Mathf.Abs(distance);

        // If the distance is smaller than 2, then the NPC will self trigger the player leave away signal
        if (distance < 1.9)
        {
            InteractableObject placer = _weaponLocation.GetComponent<InteractableObject>();
            placer.TakeWeapon();
        }
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

        // Put the murder weapon into the _weaponLocation
        GenerateMurderWeapon();

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

    public void RestoreMurderPosition()
    {
        NPC npc;
        
        // Set the NPC
        switch (_murder)
        {
            case GameMurderScenario.None: return;
            case GameMurderScenario.Lisa:
                npc = m_objectLisa.GetComponent<NPC>(); break;
            case GameMurderScenario.Mark:
                npc = m_objectMark.GetComponent<NPC>(); break;
            case GameMurderScenario.Samantha:
                npc = m_objectSamantha.GetComponent<NPC>(); break;
            default: return;
        }

        // Return the murder position
        npc.GoBack();

        // Restore the murder weapon
        GenerateMurderWeapon();
    }

    public void EndGameChecking()
    {
        print(userSelectedMurder.text);
        print(userSelectedWeapon.text);

        // Check the Murder is correct or not
        switch (_murder)
        {
            case GameMurderScenario.None: return;
            case GameMurderScenario.Lisa:
                if (string.Compare(userSelectedMurder.text, "Lisa") == 0)
                {
                    EndGameProcess = EndGameStatus.Win;
                }
                else
                {
                    EndGameProcess = EndGameStatus.Lose;
                }; break;
            case GameMurderScenario.Mark:
                if (string.Compare(userSelectedMurder.text, "Mark") == 0)
                {
                    EndGameProcess = EndGameStatus.Win;
                }
                else
                {
                    EndGameProcess = EndGameStatus.Lose;
                }; break;
            case GameMurderScenario.Samantha:
                if (string.Compare(userSelectedMurder.text, "Samantha") == 0)
                {
                    EndGameProcess = EndGameStatus.Win;
                }
                else
                {
                    EndGameProcess = EndGameStatus.Lose;
                }; break;
            default: return;
        }

        if (EndGameProcess == EndGameStatus.Win)
        {
            if (userSelectedWeapon.text == "")
            {
                EndGameProcess = EndGameStatus.Half;
            }
        }
    
        ProcessEndGameUI();
    }

    private void ProcessEndGameUI()
    {
        EndGameUI.SetActive(true);

        switch (EndGameProcess)
        {
            case EndGameStatus.None: break;
            case EndGameStatus.Win:
                EndGameUIText.text = "You Win!"; break;
            case EndGameStatus.Lose:
                EndGameUIText.text = "You Lose!"; break;
            case EndGameStatus.Half:
                EndGameUIText.text = "You are half correct! Try to get the weapon first!"; break;
            default: break;
        }
    }

}
