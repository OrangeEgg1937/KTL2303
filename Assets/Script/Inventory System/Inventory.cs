using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Inventory attributes
    [Header("Inventory Attributes")]
    [SerializeField] int capacity; // The maximum number of items that can be stored in the inventory
    [SerializeField] int currentSize; // The current number of items in the inventory
    [SerializeField] TextAsset JSON_Data; // The UI of the inventory

    List<Item> items; // The list of items in the inventory

    // When the inventory is created, create items
    void awake()
    {
        items = new List<Item>();
    }

    // Initialize the inventory from the first time
    void Start()
    {
        if (JSON_Data != null)
        {
            // import the data from JSON file
            items = JsonUtility.FromJson<Item>(JSON_Data.text);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
