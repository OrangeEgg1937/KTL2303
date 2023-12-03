using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUIAppearance: MonoBehaviour 
{
    [SerializeField] GameObject chatUI;

    public void SetAppearance(bool value)
    {

        if (chatUI == null)
        {
            print("NULL chatUI");
            return;
        }

        Canvas location = chatUI.GetComponent<Canvas>();

        if (value)
        {
            location.targetDisplay = 0;
        }
        else
        {
            location.targetDisplay = 1;
        }
    }
    
}
