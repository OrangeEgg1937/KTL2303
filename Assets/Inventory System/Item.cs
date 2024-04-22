using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
[System.Serializable]
public class Item : ScriptableObject
{
    // Item attributes
    [Header("Item Attributes")]
    [SerializeField] public int id; // The id of the item
    [SerializeField] public string items_name;
    [SerializeField] public string description;
    [SerializeField] public Sprite icon;
    [SerializeField] public bool isDiscoveredByPlayer = false;

    [Header("Status")]
    [SerializeField] public List<Status> status;

    [Header("Condition")]
    [SerializeField] public List<FavorableConditions> Condition;

    [Header("Initial Status")]
    [SerializeField] public List<Status> initStatus;

}
