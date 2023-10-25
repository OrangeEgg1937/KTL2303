using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The object in the environment that can be interacted with
public abstract class InteractableEnv : InteractableObject
{
    // Interactable object attributes
    [Header("Interactable Environment Object Attributes")]
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 1f;

    // Constructor
    protected InteractableEnv(bool upgardeable) : base(upgardeable) { }
}
