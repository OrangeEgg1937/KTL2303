// Custom Debug console 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using InGameCustomConsole.Message;
using System;
using TMPro;
using Unity.VisualScripting;

public enum ConsoleInputDisplayPos
{
    Top, Middle, Bottom
}

public enum ConsoleScaleMode
{
    Screen, Custom
}

public class DebugConsole : MonoBehaviour
{
    // MessageBuffer - saving the message log
    private List<string> messageBuffer = new List<string>();

    // Console Log windows
    [SerializeField] private GameObject m_console;

    // Message Type Handler
    [SerializeField] private MessageHandler m_MsgHandler;

    // Console style
    [SerializeField] private ConsoleInputDisplayPos m_displayPosition;

    [SerializeField] private ConsoleScaleMode m_displayScaleMode;

    // Size of the input console field
    [SerializeField] private float m_displayHeight;
    [SerializeField] private float m_displayWidth;
    [SerializeField] private float m_inputHeight = 20f;
    [SerializeField] private float m_ratio = 0.01f;

    private bool isShowConsoleInput = false;

    string input;

    private void Awake()
    {
        if (m_displayScaleMode == ConsoleScaleMode.Custom) return;
        m_displayHeight = Screen.height;
        m_displayWidth = Screen.width;
        m_inputHeight = m_displayWidth * m_ratio;
        Application.logMessageReceived += applicationLog;
    }

    public void showConsoleInput(InputAction.CallbackContext content)
    {
        Debug.Log("Message" + isShowConsoleInput);
        isShowConsoleInput = !isShowConsoleInput;
    }

    private void OnGUI()
    {
        if (m_displayScaleMode == ConsoleScaleMode.Screen)
        {
            m_displayHeight = Screen.height;
            m_displayWidth = Screen.width;
        }

        if (!isShowConsoleInput) { return; }

        GUI.Box(new Rect(0, 0, m_displayWidth, m_inputHeight), "");
        GUI.backgroundColor = Color.black;

        input = GUI.TextField(new Rect(10f, 0 + 5f, Screen.width - 20f, m_inputHeight - 10f), input);
    }

    private void applicationLog(string logString, string stackTrace, LogType type)
    {
        // Convert Unity/C# console log into ingame log
        switch(type)
        {
            case LogType.Error:     Message(logString + "\n" + stackTrace, "Error"); break;
            case LogType.Assert:    Message(logString + "\n" + stackTrace, "Normal"); break;
            case LogType.Warning:   Message(logString + "\n" + stackTrace, "Warning"); break;
            case LogType.Log:       Message(logString + "\n" + stackTrace, "Normal"); break;
            case LogType.Exception: Message(logString + "\n" + stackTrace, "Error"); break;
            default:                Message(logString + "\n" + stackTrace, "Normal"); break;
        }
    }

    public void Message(string msg, string type)
    {
        // find the prefab
        GameObject message = m_MsgHandler.getMessageTypeByName(type);

        // create the message in log
        GameObject clone = Instantiate(message, m_console.transform);

        // write the message into the clone component
        TextMeshProUGUI cloneMsg = clone.GetComponentInChildren<TextMeshProUGUI>();

        // Add the current time into msg
        msg = "[" + DateTime.Now.ToString("HH:mm:ss tt") + "] " + msg;

        // Write the message
        cloneMsg.text = msg;

        // Save the message into
        messageBuffer.Add(msg);
    }

/*    public void TestMessage()
    {
        Message("Testing by btn", "Normal");
    }*/

    public void ExportLog()
    {
        string currentDir = System.IO.Directory.GetCurrentDirectory();
        // System.IO.File.WriteAllText((currentDir + "\\log.txt"), messageBuffer.verbList);
    }
}
