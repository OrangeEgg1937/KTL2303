using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Table : InteractableObject
{
    [Header("Table field")]
    [SerializeField] private Inventory inventory; // The inventory of the wardrobe
    //[SerializeField] private GameObject Player;
    //[SerializeField] private Item item;

    [SerializeField] private List<FavorableConditions> playerCondList;// This should be in Player.cs, delete it when finished

    // Constructor
    Table() : base(false) { }

    public override bool CheckStatus(Status status, FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }
    
    public override void Interact()
    {
        base.Interact();
        
        foreach (Status item in status)
        {
            if (item != null)
            {
                if (Random.value < showStatusProbability(item, playerCondList))//replace CondList with real conditional list of player!
                    item.isHiddenAtStart = false;

            }
            
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
