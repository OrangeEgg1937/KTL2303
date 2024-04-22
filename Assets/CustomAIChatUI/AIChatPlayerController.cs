using Inworld.Sample;
using Inworld.UI;
using UnityEngine;

public class AIChatPlayerController : PlayerController
{
    [SerializeField] protected GameObject m_ChatCanvas;


    // Toggle the UI appearance
    public bool isChatUIVisible = false;

    protected override void HandleInput()
    {
        // Check the user pressed the ui key or not
        if (Input.GetKeyUp(uiKey))
        {
            isChatUIVisible = !isChatUIVisible;
        }

        // showUI();
    }

}
