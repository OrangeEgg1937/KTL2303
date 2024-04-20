using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]

// Set a generic Unity event class
public class PlayerEvent : UnityEvent<string>
{
}

public class Player : Character
{
    // Player attrubutes
    [Header("Player Attributes")]
    public uint Investigative = (uint)DataTransfer.investigation;
    public uint Interrogation = (uint)DataTransfer.interrogation;
    public uint Action = (uint)DataTransfer.action;

    // Player main items attributes
    [Header("Player Game System Attributes")]
    public List<FavorableConditions> Cules;
    
    // Player interactive handler
    [Header("Player Action Handler")]
    [SerializeField] PlayerEvent playerAction = new PlayerEvent();

    // Player Display UI related
    [Header("Interactive UI")]
    [SerializeField] private GameObject m_interactingUI;
    [SerializeField] private Material m_objectOutline;
    public bool isBusy;

    // Player current trigger
    [Header("Game system related")]
    [SerializeField] private List<Trigger> m_playerTriggerList;

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
        this.inventory.Setup();
        Cules = new List<FavorableConditions>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nearbyObject = new Collider[5];
        inventory.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        // Process the player movement
        PlayerMovement();

        // Process the nearby object
        surroundingObject();
    }

    private void PlayerMovement()
    {
        controller.SimpleMove(move);
        PlayerRotation(move);
    }

    private HashSet<MeshRenderer> m_markedObject = new HashSet<MeshRenderer>();
    void surroundingObject()
    {
        // Find the nearby object
        numOfNearbyObject = Physics.OverlapSphereNonAlloc(transform.position, searchingDistance, nearbyObject, interactionLayerMask);

        if (numOfNearbyObject > 0)
        {
            // Show the tips
            m_interactingUI.SetActive(true);

            // Adding the outline effect to the cloest object
            var currentObject = nearbyObject[0].GetComponent<MeshRenderer>();
            var objectMaterials = currentObject.materials;
            m_markedObject.Add(currentObject);
            if (objectMaterials.Length == 1)
            {
                objectMaterials = new Material[2] { objectMaterials[0], m_objectOutline };
            }
            else
            {
                objectMaterials[1] = m_objectOutline;
            }
            nearbyObject[0].GetComponent<MeshRenderer>().materials = objectMaterials;

            // Interact with the object if the E key is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Interact with the object
                InteractableObject target = nearbyObject[0].GetComponent<InteractableObject>();
                NPC NPCtarget = nearbyObject[0].GetComponent<NPC>();
                if (target != null) 
                { 
                    target.Interact();
                }
                if (NPCtarget != null)
                {
                    NPCtarget.Interact();
                }
            }

            // Remove the outline effect from the previous object
            if (m_markedObject.Count > 1)
            {
                foreach (var obj in m_markedObject)
                {
                    if (obj != currentObject)
                    {
                        obj.materials = new Material[1] { obj.materials[0] };
                    }
                }
            }
        }
        else
        {
            // Hide the tips
            m_interactingUI.SetActive(false);

            foreach (var obj in m_markedObject)
            {
                obj.materials = new Material[1] { obj.materials[0] };
            }
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
        move = input * movementSpeed * 9.81f;

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

    // Get the player trigger list
    public List<Trigger> GetPlayerTriggerList()
    {
        return m_playerTriggerList;
    }

    // Add the trigger to the player trigger list
    public void AddTrigger(Trigger trigger)
    {
        // Check the trigger is already in the list or not
        if (m_playerTriggerList.Contains(trigger))
        {
            return;
        }
        m_playerTriggerList.Add(trigger);
    }

    public void InvestigateInvItems(GameObject id)
    {
        print("Player is investigating: " + id.name + " " + inventory.GetItemInfo(int.Parse(id.name)).name);
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
