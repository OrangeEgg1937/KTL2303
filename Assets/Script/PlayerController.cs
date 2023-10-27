using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// This is the player controller
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 5f;

    // Player event handler
    UnityEvent playerAction = new UnityEvent();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    public void Move(InputAction.CallbackContext content)
    {
        // Get the input
        Vector3 input = new Vector3(content.ReadValue<Vector2>().x, 0, content.ReadValue<Vector2>().y);

        // Move the player
        rb.velocity = input * speed;
    }
}
