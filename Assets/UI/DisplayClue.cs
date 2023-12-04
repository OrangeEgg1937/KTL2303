using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayClue : MonoBehaviour
{
    // Support tips
    Player player;

    private void Awake()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }

    // Display the status
    public void DisplayPlayerClues()
    {

        // Set the child output
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (i >= player.Cules.Count)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                continue;
            }

            // Get the child gameobjcet
            StatusDisplay child = transform.GetChild(i).gameObject.GetComponent<StatusDisplay>();

            // Modify the value
            child.statusTitle = player.Cules[i].ConditionsName;
            child.description = player.Cules[i].ConditionsDescription;

            // Active the gameboject
            transform.GetChild(i).gameObject.SetActive(true);

        }
    }
}
