using Inworld.Assets;
using Inworld;
using Inworld.Packet;
using Inworld.Sample;
using Inworld.UI;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Inworld.Entities;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AIChatWindows: MonoBehaviour
{
    [SerializeField] InworldCharacter m_Character;

    [Header("Customization")]
    [SerializeField] string m_NPC_Name = "NPC";
    [SerializeField] GameObject dialogContentBox;
    [SerializeField] GameObject m_NPCMessage;
    [SerializeField] GameObject m_PlayerMessage;
    [SerializeField] private Player player;
    [SerializeField] private Button m_SendButton;
    [SerializeField] private TMP_InputField m_InputField;
    [SerializeField] private ScrollRect m_ScrollRect;

    [SerializeField] private string m_currentSelectedCharacter;

    private Dictionary<string, GameObject> m_ChatGameObject = new Dictionary<string, GameObject>();
    private string m_SendText;

    private void Awake()
    {
        print("Awake");
        // Add the button listener
        m_SendButton.onClick.AddListener(() =>
        {
            // Get the text from the input field
            m_SendText = m_InputField.text;
            if (string.IsNullOrWhiteSpace(m_SendText))
                return;

            // Send the text to the character
            m_Character.SendText(m_SendText);

            // Clear the input field
            m_InputField.text = "";
        });
        gameObject.SetActive(false);
    }

    public void CreatePlayerMessageBox(string text)
    {
        string index = text + m_ChatGameObject.Count;
        m_ChatGameObject[index] = (CreateChatMessage.CreateMessage(m_PlayerMessage, dialogContentBox.transform, text));
        m_ScrollRect.verticalNormalizedPosition = 0f;
    }

    public void CreateNPCMessageBox(string text)
    {
        string index = text + m_ChatGameObject.Count;
        m_ChatGameObject[index] = (CreateChatMessage.CreateMessage(m_NPCMessage, dialogContentBox.transform, text));
        m_ScrollRect.verticalNormalizedPosition = 0f;
    }

    private void Update()
    {
        // if user press Q, exit the chat
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(false);
            player.SetIsBusy(false);
        }
    }
}
