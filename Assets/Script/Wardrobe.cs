using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : InteractableObject
{
    [SerializeField] private Inventory inventory; // The inventory of the wardrobe
    [SerializeField] private GameObject Player;
    [SerializeField] private Item item;

    private List<Status> statusList = new List<Status>();

    // Constructor
    Wardrobe() : base(false) { }

    public override bool CheckStatus(Status status, FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        base.Interact();
        Player action = Player.GetComponent<Player>();
        if (action.bag.AddItem(item))
        {
            print("Added");
        }
    }

    public override void Interact(GameObject target)
    {

    }

    public override void Upgrade(GameObject source)
    {

    }

    private void Awake()
    {
        gameObject.layer = INTERACTABLE_OBJECT_LAYER_CODE;
    }


    // Start is called before the first frame update
    void Start()
    {
        inventory.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
