using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// The central system to listen the character and environment changing 
public class GameEnvironmentHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_EventMessageDisplayer;

    public void ErrorMessage()
    {
        print("TEST");
    }


    public void WriteEventMessage(string message)
    {
        m_EventMessageDisplayer.text = "Game event: " + message;
    }
}
