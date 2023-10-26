using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Player : Character
{
    // Player attributes
    [Header("Player Attributes")]
    [SerializeField] private float speed = 5f; // Moving speed of the player
    private Rigidbody rigidbody; // Rigidbody of the player

    // Constructor
    Player() : base(99999U) {}

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
        
    }

    // Move the player
    public void Move(InputAction.CallbackContext content)
    {
        // Get the input
        Vector3 input = new Vector3(content.ReadValue<Vector2>().x, 0, content.ReadValue<Vector2>().y);

        // Move the player
        rigidbody.velocity = input * speed;
    }
}
