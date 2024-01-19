using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndProcess : MonoBehaviour
{
    // [SerializeField] InworldAIEventHandler handler;
    [SerializeField] TMPro.TMP_Dropdown weapon;
    [SerializeField] TMPro.TMP_Dropdown murder;

    public void gameEnd()
    {
        //get the selected index
/*        bool isPlayerWin = handler.CheckWinCondition(
            weapon.options[weapon.value].text,
            murder.options[murder.value].text);*/

/*        if (isPlayerWin)
        {
            handler.DisplayEndGameInfo(0);
        }
        else
        {
            gameEnd(2);
        }
        handler.DisplayEndGameInfo(1);*/
    }

    public void gameEnd(int code)
    {
        // Timeout
        if (code == 1)
        {
            print("Game ended with timeout!");
        }

        // Wrong Answer
        if (code == 2)
        {
            print("Game ended with wrong answer!");
        }

        // handler.DisplayEndGameInfo(1);
    }
    
}
