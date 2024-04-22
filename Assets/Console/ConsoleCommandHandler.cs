using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ConsoleInputDisplayPos
{
    Top, Middle, Bottom
}

public enum ConsoleScaleMode
{
    Screen, Custom
}


public class ConsoleCommandHandler : MonoBehaviour
{
    private DebugConsoleLogHandler m_ConsoleLogHandler;

    // Size of the input console field
    [SerializeField] private float m_displayHeight;
    [SerializeField] private float m_displayWidth;
    [SerializeField] private float m_inputHeight = 20f;
    [SerializeField] private float m_ratio = 0.01f;

    private bool isShowConsoleInput = false;

    string input;

    // Console style
    /*    [SerializeField] private ConsoleInputDisplayPos m_displayPosition;
        [SerializeField] private ConsoleScaleMode m_displayScaleMode;*/


    // get the console log window object
    private void Awake()
    {
        m_displayHeight = Screen.height;
        m_displayWidth = Screen.width;
        m_inputHeight = m_displayWidth * m_ratio;
        m_ConsoleLogHandler = FindFirstObjectByType<DebugConsoleLogHandler>();
    }

    public void showConsoleInput(InputAction.CallbackContext content)
    {
        Debug.Log("Message" + isShowConsoleInput);
        isShowConsoleInput = !isShowConsoleInput;
    }

    private void OnGUI()
    {
        if (!isShowConsoleInput) { 
            input = ""; 
            return; 
        }

        GUI.Box(new Rect(0, 0, m_displayWidth, m_inputHeight), "");
        GUI.backgroundColor = Color.black;

        input = GUI.TextField(new Rect(10f, 0 + 5f, Screen.width - 20f, m_inputHeight - 10f), input);
    }
}
