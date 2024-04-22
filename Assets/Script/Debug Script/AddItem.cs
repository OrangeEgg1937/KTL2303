using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AddItem : MonoBehaviour
{
    Player player;
    DialogBox dialogBox;
    [SerializeField] GameObject d_box;
    [SerializeField] GameObject Player;
    [SerializeField] Scenario scenario;
    [SerializeField] Item item;

    private void Awake()
    {
        player = Player.GetComponent<Player>();    
        dialogBox = d_box.GetComponent<DialogBox>();

        // Reset the scenario
        scenario.ResetScenario();
    }

    public void AddAnyItem()
    {
        player.inventory.AddItem(item);
        print("Testing");
    }

    public void LoadScenarioIntoDialogBox()
    {
        // Reset the scenario
        scenario.ResetScenario();

        dialogBox.loadCurrentScenario(scenario, Player);
        dialogBox.DialogFrame.SetActive(true);
    }
}
