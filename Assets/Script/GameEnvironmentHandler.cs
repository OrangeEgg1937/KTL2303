using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The central system to listen the character and environment changing 
public class GameEnvironmentHandler : MonoBehaviour
{
    private string logger;

    // Write the message to the logger
    public void WriteLog(string message)
    {
        logger += "[" + Time.realtimeSinceStartup + "]" + message + "\n";
        print(message);
    }

    public void ErrorMessage()
    {
        print("TEST");
    }

    // Save the log into the current directory
    public void ExportLog()
    {
        string currentDir = System.IO.Directory.GetCurrentDirectory();
        System.IO.File.WriteAllText((currentDir+"\\log.txt"), logger);
    }

    // Check the status of two gameobject is 
}
