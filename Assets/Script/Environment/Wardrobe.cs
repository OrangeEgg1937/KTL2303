using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : InteractableObject
{
    [SerializeField] private Item item;
    [SerializeField] private Item items2;

    private List<Status> statusList = new List<Status>();


    public override bool CheckStatus(Status status, FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        base.Interact();
        if (player.bag.AddItem(item))
        {
            print("Added");
        }
        if (player.bag.AddItem(items2))
        {
            print("Added Book");
        }
    }

    public override void Interact(GameObject target)
    {

    }

    public override void Upgrade(GameObject source)
    {

    }

    protected override void Awake()
    {
        base.Awake();
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
