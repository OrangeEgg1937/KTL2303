using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define status interface
public interface IStatusProperty
{
    // Checking the status is exist in the object or not
    public bool CheckStatus(Status status);
    public bool CheckStatus(Status status, FavorableConditions conditions);

    // Adding the status into the object
    public void AddStatus(Status status);

    // Remove the status into the object
    public void RemoveStatus(Status status);

}
