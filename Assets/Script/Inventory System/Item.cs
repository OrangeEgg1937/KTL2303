using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : InteractableObject
{
    // Item attributes
    [Header("Item Attributes")]
    [SerializeField] private int id; // The id of the item

    // Constructor
    protected Item(bool upgardeable) : base(upgardeable) { }
}
