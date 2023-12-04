using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInfo : MonoBehaviour
{
    [SerializeField] GameObject clueDisplay;

    DisplayClue disaply;

    private void Awake()
    {
        disaply = clueDisplay.GetComponent<DisplayClue>();
    }

    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 3)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        disaply.DisplayPlayerClues();
    }
}
