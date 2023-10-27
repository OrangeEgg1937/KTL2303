using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : InteractableEnv
{
    [SerializeField] private Inventory inventory; // The inventory of the wardrobe

    // Constructor
    Wardrobe() : base(false) { }

    public override void Interact()
    {
        
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
