using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game Attribute")]
    public int gamePhrase = 0;
    public int killer;

    [Header("Player")]
    public Player player;


    [Header("Weapon")]
    public List<Item> murderWeaponList = new List<Item>();
    public Item commonWeapon;
    private Item currentWeapon;
    public float getWeaponChance;

    [Header("CheckIfGetWeapon")]
    public List<Trigger> triggerList = new List<Trigger>();

    [Header("GameEnd")]
    public GameObject endscreen;
    public TMP_Dropdown answer;
    public TextMeshProUGUI text;
    private List<string> killerName = new List<string>();
    
    //use additem script to put introduction into dialogbox and initilize killer
    void Start()
    {
        AddItem Narrator = GetComponent<AddItem>();
        Narrator.LoadScenarioIntoDialogBox();
        killer = Random.Range(0, 3);
        killerName.Add("Samentha");
        killerName.Add("Mark");
        killerName.Add("Lisa");
        currentWeapon = murderWeaponList[killer];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // check who is the winner and show it to pthe screen
    public void checkwin()
    {
        endscreen.SetActive(true);
        if (answer.value == killer)
        {
            text.text = "You Win! The killer is " + killerName[killer];
        }
        else
        {
            text.text = "You lose! The killer is " + killerName[killer];
        }

    }

    //Do it when interact with interactable object. have "getWeaponChance"% chance to get item and 
    //50% gettinng common weapon
    public bool GetItemInteract()
    {

        if (gamePhrase == 1)
        {
            //check if have the required triggers
            int triggerCount = 0;
            foreach (Trigger trigger in triggerList)
            {
                if (player.GetPlayerTriggerList().Contains(trigger))
                    triggerCount++;
            }
            if (triggerCount == 0)
            {
                //return true means the object is interacted any shall not be interact again
                return true;
            }

            // start lottery
            if (!player.inventory.items.Contains(currentWeapon) && !player.inventory.items.Contains(commonWeapon))
            {
                int lottery = Random.Range(0, 100);
                if (lottery > 0 && lottery < (int)(getWeaponChance * 100))
                {
                    if (Random.Range(0, 2) == 1)
                    {
                        player.inventory.AddItem(currentWeapon);
                        print("Get item " + currentWeapon.name);
                    }
                    else
                    {
                        player.inventory.AddItem(commonWeapon);
                        print("Get item " + commonWeapon.name);
                    }
                }
                return true;
            }
        }
        return false;

    }
}