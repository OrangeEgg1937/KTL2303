using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInfo : MonoBehaviour
{
    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 3)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
    }
}
