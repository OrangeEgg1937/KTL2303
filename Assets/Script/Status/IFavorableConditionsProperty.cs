using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define status interface
public interface IFavorableConditionsProperty
{
    // Checking the Conditions is exist in the object or not
    public bool CheckCondition(FavorableConditions conditions);

    // Adding the condition into the object
    public void AddCondition(FavorableConditions conditions);

    // Remove the status into the object
    public void ReomveCondition(FavorableConditions conditions);

}
