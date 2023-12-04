using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStatus : MonoBehaviour
{
    // Support tips
    [SerializeField] GameObject tips;

    // Display the status
    public void DisplayStatusDetail(Item item)
    {
        tips.SetActive(false);

        // Set the child output
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (item == null)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            if (i >= item.status.Count)
            {
                transform.GetChild(i).gameObject.SetActive(false);
                continue;
            }

            // Get the child gameobjcet
            StatusDisplay child = transform.GetChild(i).gameObject.GetComponent<StatusDisplay>();


            if (item.status[i].isHiddenAtStart && !item.status[i].isDiscover)
            {
                tips.SetActive(true);
                transform.GetChild(i).gameObject.SetActive(false);
                continue;
            }
            // Modify the value
            child.statusTitle = item.status[i].statusName;
            child.description = item.status[i].statusDescription;

            // Active the gameboject
            transform.GetChild(i).gameObject.SetActive(true);

        }
    }
}
