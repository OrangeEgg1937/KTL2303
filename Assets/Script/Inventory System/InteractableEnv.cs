using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The object in the environment that can be interacted with
public abstract class InteractableEnv : InteractableObject
{
    // Constructor
    protected InteractableEnv(bool upgardeable) : base(upgardeable) { }
}
