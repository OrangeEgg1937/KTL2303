using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Character
{
    // The target location
    [SerializeField] Transform destination;
    // [SerializeField] InworldAIEventHandler eventHandler;
    [SerializeField] GameObject ItemsList;
    [SerializeField] DialogBox dialogbox;
    [SerializeField] GameFlow gameflow;

    // Private member of NPC
    private NavMeshAgent agent;     // NavMeshAgent for NPC movement
    private LevelBuilder levelbuilder;

    // Get the component of the player
    private void Awake()
    {
        levelbuilder = (LevelBuilder) FindAnyObjectByType(typeof(LevelBuilder));
    }

    // Start is called before the first frame update
    void Start()
    {
        nearbyObject = new Collider[5];
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //agent.destination = destination.position;
    }

    // NPC moving
    public void Move(Vector3 destination)
    {
        agent.destination = destination;
    }

    // NPC interact
    public void Interact()
    {
        currentScenario = scenarioList[gameflow.killer];
        dialogbox.loadCurrentScenario(currentScenario, gameObject);
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
