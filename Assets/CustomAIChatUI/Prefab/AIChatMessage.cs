using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class CreateChatMessage
{
    public static GameObject CreateMessage(GameObject prefab, Transform parent, string message)
    {
        GameObject messageObj = Object.Instantiate(prefab, parent);
        messageObj.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = message;
        return messageObj;
    }
}