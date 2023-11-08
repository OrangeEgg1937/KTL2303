using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour, IPlaneDisplay
{
    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 0)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
    }
}
