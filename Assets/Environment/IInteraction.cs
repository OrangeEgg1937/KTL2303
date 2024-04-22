using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{
    // Interactable object attributes
    // We don't need the name of the object
    // because we can get it by using gameObject.name from MonoBehaviour    
    public const int INTERACTABLE_OBJECT_LAYER_CODE = 6;
    public void Interact();
}
