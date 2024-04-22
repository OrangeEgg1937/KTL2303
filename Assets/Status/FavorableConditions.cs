using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "FavorableConditions", menuName = "Conditions", order = 1)]
[System.Serializable]
public class FavorableConditions : ScriptableObject
{
    public string ConditionsName;
    public string ConditionsDescription;
}
