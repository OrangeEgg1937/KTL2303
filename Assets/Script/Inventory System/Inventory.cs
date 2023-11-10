using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    // Inventory attributes
    [Header("Inventory Attributes")]
    [SerializeField] private int capacity = 10; // The maximum number of items that can be stored in the inventory
    [SerializeField] private int currentSize = 0; // The current number of items in the inventory
    [SerializeField] private TextAsset JSON_Data; // The initial of the inventory

    List<Item> items; // The list of items in the inventory
    
    public int CurrentSize()
    {
        return currentSize;
    }

    // Setup the inventory
    public void Setup()
    {
        if (JSON_Data != null)
        {
            // import the data from JSON file from array to list
            items = new List<Item> { JsonUtility.FromJson<Item>(JSON_Data.text) };
        }
        else
        {
            items = new List<Item>();
        }
    }

    // Add an item to the inventory
    public bool AddItem(Item item)
    {
        if (currentSize < capacity)
        {
            items.Add(item);
            currentSize++;
            return true;
        }
        else return false;
    }

    // Take the item from the inventory
    public Item TakeItem(int index)
    {
        if (index < currentSize)
        {
            Item item = items[index];
            items.RemoveAt(index);
            currentSize--;
            return item;
        }
        else return null;
    }

    // Get Item info
    public Item GetItemInfo(int index)
    {
        if (index < currentSize)
        {
            return items[index];
        }
        else return null;
    }

    // Get the item list from the inventory
    public List<Item> GetItemList()
    {
        return items;
    }
}
