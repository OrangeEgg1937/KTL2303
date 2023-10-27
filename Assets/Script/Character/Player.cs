using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[System.Serializable]

// Set a generic Unity event class
public class PlayerEvent : UnityEvent<string>
{
}

public class Player : Character
{
    // Player attributes
    [Header("Player Attributes")]
    [SerializeField] private float speed = 5f; // Moving speed of the player
    private Rigidbody rigidbody; // Rigidbody of the player

    // Player interactive handler
    [Header("Player Action Handler")]
    [SerializeField] PlayerEvent playerAction = new PlayerEvent();

    // Constructor
    Player() : base(99999U) { }

    // Get the component of the player
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Find the nearby object
        nearbyObject = Physics.OverlapSphere(transform.position, searchingDistance, interactionLayerMask);

        numOfNearbyObject = nearbyObject.Length;

        if (numOfNearbyObject > 0 && Input.GetKeyDown(KeyCode.E))
        {
            // Show the tips
            transform.GetChild(0).gameObject.SetActive(true);

            // Interact with the object
            var target = nearbyObject[0].GetComponent<InteractableObject>();
            if (target != null) { target.Interact(); }

            // Trigger the listener
            playerAction.Invoke("Player interact with " + target.name);
        }
        else
        {
            // Hide the tips
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Move the player
    public void Move(InputAction.CallbackContext content)
    {
        // Get the input
        Vector3 input = new Vector3(content.ReadValue<Vector2>().x, 0, content.ReadValue<Vector2>().y);

        // Move the player
        rigidbody.velocity = input * speed;

        // Telling to the game enivronment
        playerAction.Invoke("Player moving to " + transform.position.x + ":" + transform.position.z);
    }
}
