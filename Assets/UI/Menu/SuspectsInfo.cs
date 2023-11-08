using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectsInfo : MonoBehaviour, IPlaneDisplay
{
    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 1)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
    }
}
