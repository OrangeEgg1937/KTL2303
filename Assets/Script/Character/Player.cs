using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
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
    [SerializeField] private float speed = 2.0f; // Moving speed of the player
    [SerializeField] private GameObject model;
    [SerializeField] public List<FavorableConditions> Cules;
    public uint Investigative = (uint)DataTransfer.investigation;
    public uint Interrogation = (uint)DataTransfer.interrogation;
    public uint Action = (uint)DataTransfer.action;
    public string bio = "This is player bio";
    
    // Player interactive handler
    [Header("Player Action Handler")]
    [SerializeField] PlayerEvent playerAction = new PlayerEvent();

    // Player Display UI related
    [SerializeField] GameObject PlayerItemsUI;

    [SerializeField] public bool isBusy;

    // Constructor
    Player() : base(99999U) { }

    // Private member for the components
    private CharacterController controller;
    private Animator animator;
    private bool isMoving;
    private Vector3 move;

    public void SetIsBusy(bool input) { isBusy = input; }

    // Get the component of the player
    private void Awake()
    {
        // Assign the component
        controller = GetComponent<CharacterController>();
        animator = model.GetComponent<Animator>();
        this.bag.Setup();
        Cules = new List<FavorableConditions>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nearbyObject = new Collider[5];
        bag.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        controller.SimpleMove(move);
        PlayerRotation(move);
        // Find the nearby object
        numOfNearbyObject = Physics.OverlapSphereNonAlloc(transform.position, searchingDistance, nearbyObject, interactionLayerMask);

        if (numOfNearbyObject > 0)
        {
            // Show the tips
            transform.GetChild(0).gameObject.SetActive(true);

            // Interact with the object if the E key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Interact with the object
                InteractableObject target = nearbyObject[0].GetComponent<InteractableObject>();
                if (target != null) { target.Interact(); }

                // Trigger the listener
                playerAction.Invoke("Player interact with " + target.name);
            }

        }
        else
        {
            // Hide the tips
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Handle Rotation
    void PlayerRotation(Vector3 target)
    {
        Vector3 lookat;
        lookat.x = target.x;
        lookat.y = 0.0f;
        lookat.z = target.z;
        Quaternion currentRotation = model.transform.rotation;

        if(isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookat);
            model.transform.rotation = Quaternion.Slerp(currentRotation,
                targetRotation,
                (20.0f * Time.deltaTime));
        }
    }

    // Move the player
    public void OnPlayerMove(InputAction.CallbackContext content)
    {
        // Get the input
        Vector3 input = new Vector3(content.ReadValue<Vector2>().x, 0, content.ReadValue<Vector2>().y);

        // Move the player
        move = input * speed * 9.81f * Time.deltaTime;

        // Switch the animation
        if (move == Vector3.zero || isBusy)
        {
            animator.SetBool("isWalking", false);
            move = Vector3.zero;
            isMoving = false;
        }
        else
        {
            animator.SetBool("isWalking", true);
            isMoving = true;
        }
    }

    public void CheckInvItem(GameObject id)
    {
        print("Player is checking: " + id.name + " " + bag.GetItemInfo(int.Parse(id.name)).name);
        PlayerItemsUI.SendMessage("DisplayStatusDetail", bag.GetItemInfo(int.Parse(id.name)), SendMessageOptions.DontRequireReceiver);
    }

    public void InvestigateInvItems(GameObject id)
    {
        print("Player is investigating: " + id.name + " " + bag.GetItemInfo(int.Parse(id.name)).name);
        PlayerItemsUI.SendMessage("DisplayStatusDetail", bag.GetItemInfo(int.Parse(id.name)), SendMessageOptions.DontRequireReceiver);
        this.Action -= 1;
    }

    public override bool CheckStatus(Status status)
    {
        throw new NotImplementedException();
    }

    public override bool CheckStatus(Status status, FavorableConditions conditions)
    {
        throw new NotImplementedException();
    }

    public override void AddStatus(Status status)
    {
        throw new NotImplementedException();
    }

    public override void RemoveStatus(Status status)
    {
        throw new NotImplementedException();
    }
}
