using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "Status", menuName = "Status", order = 1)]
[System.Serializable]
public class Status : ScriptableObject
{
    public string statusName;
    public string statusDescription;
}
