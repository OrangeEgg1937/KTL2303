using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a base class for all interactable objects in the game
public abstract class InteractableObject : MonoBehaviour
{
    // Interactable object attributes
    // We don't need the name of the object
    // because we can get it by using gameObject.name from MonoBehaviour
    public const int INTERACTABLE_OBJECT_LAYER_CODE = 6;

    private bool isUpgardeable; // Can the object be upgraded
    public List<Status> status;

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

    // Check the input status is exist in the list or not
    public bool CheckStatus(Status status)
    {
        print("This status is:" + this.status.Contains(status));
        return this.status.Contains(status);
    }

    public void AddStatus(Status status)
    {
        // If the status not in the object list, add it into the list
        if (!CheckStatus(status)) this.status.Add(status);
    }

    public void RemoveStatus(Status status)
    {
        // If the status in the object list, remove it from the list
        if (CheckStatus(status))
        {
            int index = this.status.IndexOf(status);
            this.status.RemoveAt(index);
        }
    }
}
