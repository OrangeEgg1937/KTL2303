using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour, IPlaneDisplay
{
    [SerializeField] private GameObject investigative;
    [SerializeField] private GameObject interrogation;
    [SerializeField] private GameObject action;
    [SerializeField] private GameObject player;

    public void DisplayInfo(int id)
    {
        if (id != 0)
        {
            gameObject.SetActive(false);
            return;
        }

        // Get the string of the gameobject
        TextMeshProUGUI display = investigative.GetComponent<TextMeshProUGUI>();
        Player player = this.player.GetComponent<Player>();

        if (display == null) {return; }
        if (player == null) {return; }

        display.text = player.Investigative.ToString();
        
        display = interrogation.GetComponent<TextMeshProUGUI>();
        display.text = player.Interrogation.ToString();

        display = action.GetComponent<TextMeshProUGUI>();
        display.text = player.Action.ToString();

        gameObject.SetActive(true);
    }
}
