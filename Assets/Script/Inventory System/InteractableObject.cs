using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a base class for all interactable objects in the game
public abstract class InteractableObject : MonoBehaviour
{
    // Interactable object attributes
    // We don't need the name of the object
    // because we can get it by using gameObject.name from MonoBehaviour

    private bool isUpgardeable; // Can the object be upgraded

    // Constructor
    protected InteractableObject(bool upgardeable)
    {
        isUpgardeable = upgardeable;
    }

    // Use method to interact with the object
    public abstract void Interact(); // Holder interact with the object ONLY
    public abstract void Interact(GameObject target); // Holder interact with the object to a target
    
    // Upgrading the object
    public abstract void Upgrade(GameObject source);
}
