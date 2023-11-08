using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Define a NPC Class
public class NPC : Character
{
    // The target location
    [SerializeField] Transform destination;

    // Private member of NPC
    private NavMeshAgent agent;     // NavMeshAgent for NPC movement
    private Rigidbody rigidbody; // Rigidbody of the player

    // Get the component of the player
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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
}
