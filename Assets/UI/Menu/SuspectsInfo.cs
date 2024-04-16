using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuspectsInfo : MonoBehaviour, IPlaneDisplay
{
    [SerializeField] TMP_Dropdown dropDownmenu;
    [SerializeField] Player player;
    public void DisplayInfo(int id)
    {
        print("Message received: " + id);
        if (id != 1)
        {
            gameObject.SetActive(false);
            return;
        }

        // Setup the dropdown data
        dropDownmenu.ClearOptions();

        foreach(var item in player.inventory.items)
        {
            TMP_Dropdown.OptionData temp = new TMP_Dropdown.OptionData();
            temp.text = item.name;
            temp.image = item.icon;

            dropDownmenu.options.Add(temp);
        }

        gameObject.SetActive(true);
    }
}
