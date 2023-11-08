using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryInfo : MonoBehaviour, IPlaneDisplay
{
    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 2)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
    }
}
