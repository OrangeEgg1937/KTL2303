using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ListItems : MonoBehaviour
{
    public GameObject player;

    // List all items from player
    private void OnEnable()
    {
        Inventory inventory = player.GetComponent<Player>().bag;
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
            Item item = inventory.TakeItem(i);

            // Write the item info to the child box
            GameObject displayObject = transform.GetChild(i).gameObject;

            // Check null
            if (displayObject != null)
            {
                continue;
            }

            // Display image
            Image image = displayObject.GetComponentInChildren<Image>();
            image.sprite = item.icon;

            // Display text
            TextMeshProUGUI displayText = displayObject.GetComponentInChildren<TextMeshProUGUI>();
            displayText.text = item.name;
        }
    }
}
