using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inworld.Entities;
using static UnityEditor.Progress;
using UnityEngine.InputSystem;
using Inworld;

public class InworldAIEventHandler : MonoBehaviour
{
    [SerializeField] private Inworld.InworldController controller;
    [SerializeField] private Inworld.Sample.CharSelectorPanel characterSelectorPanel;
    [SerializeField] private List<InworldCharacterData> characterDataList;
    [SerializeField] private bool isReady = false;

    [SerializeField] private Inworld.InworldCharacter Ben;
    [SerializeField] private Inworld.InworldCharacter Jack;
    [SerializeField] private Inworld.InworldCharacter David;

    [SerializeField] private GameObject ChatWindows;
    [SerializeField] private GameObject initial_Windows;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameEnvironmentHandler gameEnvironmentHandler;

    [SerializeField] private string m_murder = "";
    [SerializeField] private Item m_weapon;
    
    public bool isSetupEnd = false;

    System.Random random = new System.Random();

    private void Awake()
    {
        isReady = characterSelectorPanel.IsUIReady;
    }

    // Start is called before the first frame update
    void Start()
    {
        isReady = characterSelectorPanel.IsUIReady;
    }

    // Update is called once per frame
    void Update()
    {
        isReady = characterSelectorPanel.IsUIReady;
    }

    public void SetMurder(string murder)
    {
        m_murder = murder;
        gameEnvironmentHandler.WriteEventMessage("Murder selected, is " + m_murder);
    }

    public void SetWeapon(Item weapon)
    {
        m_weapon = weapon;
    }

    public void receiveCharacter(InworldCharacterData agent)
    {
        characterDataList.Add(agent);
        if (string.Compare(agent.brainName, "workspaces/ktl2303/characters/ben") == 0)
        {
            Ben.Data = agent;
        }
        else if (string.Compare(agent.brainName, "workspaces/ktl2303/characters/jack") == 0)
        {
            Jack.Data = agent;
        }else if (string.Compare(agent.brainName, "workspaces/ktl2303/characters/david") == 0)
        {
            David.Data = agent;
        }

        if (characterDataList.Count >= 3)
        {
            StartCoroutine(waitForConnection());
        }
    }

    public void sendMessageToCharacter(string message)
    {
        StartCoroutine(ClearChatLogForStart());
    }

    IEnumerator waitForConnection()
    {
        while (InworldController.Status != InworldConnectionStatus.Connected)
        {
            yield return null;
        }

        sendMessageToCharacter("Temp");
        StopCoroutine(waitForConnection());

        yield return null;
    }

    IEnumerator ClearChatLogForStart()
    {
        while (!isSetupEnd)
        {
            print("Murder not selecting yet.");
            // Selecting character
            int num = random.Next(3);
            print("ID=["+ num + "] Selected: " + characterDataList[num].agentId);
            controller.SendText(characterDataList[num].agentId, "You feel that now have a chance to take Alex life.");
            Destroy(ChatWindows.transform.GetChild(0).gameObject);
            yield return new WaitForSecondsRealtime(1);
        }
        print("Murder selected");

        // Select the Murder Weapon
        if (string.Compare(m_murder, "ben") == 0)
        {
            controller.SendText(Ben.ID, "You try to find a murder weapon to kill alex.");
            Destroy(ChatWindows.transform.GetChild(0).gameObject);
            yield return new WaitForSecondsRealtime(1);
        }else if (string.Compare(m_murder, "jack") == 0)
        {
            controller.SendText(Jack.ID, "You try to find a murder weapon to kill alex.");
            Destroy(ChatWindows.transform.GetChild(0).gameObject);
            yield return new WaitForSecondsRealtime(1);
        }
        else
        {
            controller.SendText(David.ID, "You try to find a murder weapon to kill alex.");
            Destroy(ChatWindows.transform.GetChild(0).gameObject);
            yield return new WaitForSecondsRealtime(1);
        }

        // Destory all child (clear the log)
        while (ChatWindows.transform.childCount != 0)
        {
            Destroy(ChatWindows.transform.GetChild(0).gameObject);
            yield return new WaitForSecondsRealtime(1);
        }

        Timer.SetActive(true);
        initial_Windows.SetActive(false);

        yield return null;
    }
}
