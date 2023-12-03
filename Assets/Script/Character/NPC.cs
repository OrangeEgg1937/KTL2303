using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Define a NPC Class
public class NPC : Character
{
    // The target location
    [SerializeField] Transform destination;
    [SerializeField] InworldAIEventHandler eventHandler;
    [SerializeField] GameObject ItemsList;

    // Private member of NPC
    private NavMeshAgent agent;     // NavMeshAgent for NPC movement

    // Get the component of the player
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        nearbyObject = new Collider[5];
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = destination.position;
    }

    // NPC moving
    public void Move(Vector3 destination)
    {
        agent.destination = destination;
    }

    // NPC interact
    public void Interact()
    {

    }

    // When trigger is activated, generate potion
    public void OnGoalComplete(string message)
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
            // eventHandler.SetWeapon(0);
        }
    }

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
