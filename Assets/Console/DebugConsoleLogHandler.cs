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
using System.IO;
using UnityEngine.UI;


public class DebugConsoleLogHandler : MonoBehaviour
{
    // MessageBuffer - saving the message log
    private List<string> messageBuffer = new List<string>();

    // Console Log windows
    [SerializeField] private GameObject m_display_content;

    // Message Type Handler
    [SerializeField] private MessageHandler m_MsgHandler;
    [SerializeField] private ScrollRect m_scrollRect;

    private void Awake()
    {
        Application.logMessageReceived += applicationLog;
        Debug.Log("Console init finished.");
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

        if (message == null) { throw new NullReferenceException(); }

        // create the message in log
        GameObject clone = Instantiate(message, m_display_content.transform);

        // write the message into the clone component
        TextMeshProUGUI cloneMsg = clone.GetComponentInChildren<TextMeshProUGUI>();

        // Add the current time into msg
        msg = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + msg;

        // Write the message
        cloneMsg.text = msg;

        // Save the message into
        messageBuffer.Add(msg);

        // Update the scrollbar
        m_scrollRect.verticalNormalizedPosition = 0;
    }

#if UNITY_EDITOR
    public void TestMessage()
    {
        Message("Testing by btn", "Normal");
    }

    public void TestNullMsg()
    {
        Message("Testing by btn", "Not exist");
    }
#endif

    // Export the message log to txt
    public void ExportToTextFile()
    {
        string filePath = System.IO.Directory.GetCurrentDirectory();

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath+ "\\log.txt"))
            {
                foreach (string message in messageBuffer)
                {
                    writer.WriteLine(message);
                }
            }

            Debug.Log("Export successful: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Export failed: " + e.Message);
        }
    }

    // Clear all log
    // At some point, the application log will save in the editor
    void OnApplicationQuit()
    {
        // Remove all log object
        ClearConsoleLogWindows();

        Debug.Log("Cleared!");
    }

    // Clear all console log
    private void ClearConsoleLogWindows()
    {
        // Remove all log object
        foreach (Transform child in m_display_content.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
