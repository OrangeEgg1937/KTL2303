using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ListItems : MonoBehaviour
{
    public GameObject player;

    // List all items from player
    private void OnEnable()
    {
        Inventory inventory = player.GetComponent<Player>().inventory;
        int inventorySize = inventory.CurrentSize();
        int childSize = transform.childCount;

        for (int i = 0; i < childSize; ++i)
        {
            // Set active to false if the object pool size is greater than inventory size
            if (i >= inventorySize)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                continue;
            }

            // Set active
            transform.GetChild(i).gameObject.SetActive(true);

            // Get the inventory items
            Item item = inventory.GetItemInfo(i);

            // Write the item info to the child box
            DisplayItemInfo displayObject = transform.GetChild(i).gameObject.GetComponent<DisplayItemInfo>();

            // Check null
            if (displayObject == null)
            {
                continue;
            }

            displayObject.UpdateInfo(item, i);

        }
    }
}
