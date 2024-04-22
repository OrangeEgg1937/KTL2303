using System.Collections;
using System.Collections.Generic;
using Inworld;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Character, IInteraction
{
    // The target location
    [SerializeField] Transform destination;
    // [SerializeField] InworldAIEventHandler eventHandler;
    [SerializeField] GameObject ItemsList;

    [SerializeField] GameObject player;

    [Header("NPC Dialog Windows")]
    [SerializeField] GameObject dialogWindow;
    [SerializeField] InworldCharacter m_character;

    [Header("NPC Movement")]
    [SerializeField] NavMeshAgent m_npcNavMeshAgent;
    [SerializeField] Transform m_npcDestination;
    [SerializeField] bool isExcuteMovement = false;
    [SerializeField] bool isExcuteBack = false;
    [SerializeField] bool isHideWeaponTriggerSend = false;
    public bool isInvestigationStage = false;

    private Player playerControl;      // The player object
    private Transform m_originalPos;

    // Get the component of the player
    private void Awake()
    {
        playerControl = player.GetComponent<Player>();
        m_npcNavMeshAgent.destination = gameObject.transform.position;
        m_originalPos = gameObject.transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (isExcuteMovement)
        {
            m_npcNavMeshAgent.destination = m_npcDestination.position;
        }
        if (isExcuteBack)
        {
            m_npcNavMeshAgent.destination = m_originalPos.position;
        }

        if(isInvestigationStage)
        {
            // Check the distance between the NPC and the destination
            withPlayerDistance();
        }
    }

    private void withPlayerDistance()
    {
        float distance = 0.0f;
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        distance = Mathf.Abs(distance);

        // If the distance is more than 2, then the NPC will self trigger the player leave away signal
        if (distance > 2 && !isHideWeaponTriggerSend)
        {
            isHideWeaponTriggerSend = true;
            InworldCharacter npcCharacter = gameObject.GetComponent<InworldCharacter>();
            npcCharacter.SendTrigger("player_leave_far_away");
        }
    }

    public void StopMovement()
    {
        isExcuteMovement = false;
        isExcuteBack = false;
    }

    public void GoBack()
    {
        isExcuteMovement = false;
        isExcuteBack = true;
    }


    // NPC moving
    public void SetDestination(GameObject gameObject)
    {
        m_npcDestination.position = gameObject.transform.position;
        isExcuteMovement = true;
    }

    public void SetDestination(Transform gameObject)
    {
        m_npcDestination.position = gameObject.position;
        isExcuteMovement = true;
    }

    public void SetDestination(Vector3 pos)
    {
        m_npcDestination.position = pos;
        isExcuteMovement = true;
    }

    // NPC interact
    public void Interact()
    {
        // Open the dialog window
        dialogWindow.SetActive(true);

        // set the player busy
        playerControl.SetIsBusy(true);

        // set the current character
        InworldController.CurrentCharacter = m_character;

        print("Current Character: " + InworldController.CurrentCharacter.ID);
    }

    // When trigger is activated, generate potion
/*    public void OnGoalComplete(string message)
    {
        print("Trigger Event: " + message);

        // Setup the murder
        if (string.Compare(message, "murder_1") == 0)
        {
            eventHandler.isSetupEnd = true;
            eventHandler.SetMurder(gameObject.name);
        }

        // Setup the weapon
        if (string.Compare(message, "weapon_0") == 0)
        {
            print(gameObject.name + "Weapon 0 selected");
            eventHandler.SetWeapon(levelbuilder.GetItemById(0));
        }

        // Set the weapon
        if (string.Compare(message, "weapon_1") == 0)
        {
            print(gameObject.name + "Weapon 0 selected");
            int weapon_code = 0;
            switch (gameObject.name)
            {
                case "ben": weapon_code = 2; break;
                case "david": weapon_code = 3; break;
                case "jack": weapon_code = 4; break;
                default: break;
            }
            eventHandler.SetWeapon(levelbuilder.GetItemById(weapon_code));
            levelbuilder.AddStatisToItemInItemList(levelbuilder.GetStatusById(0), weapon_code);
        }
    }*/

    public override bool CheckStatus(Status status)
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckStatus(Status status, FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }

    public override void AddStatus(Status status)
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveStatus(Status status)
    {
        throw new System.NotImplementedException();
    }
}
