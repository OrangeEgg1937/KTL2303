using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image DisplayImage;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private Button InvestigateBtn;
    [SerializeField] private Button CheckBtn;
    [SerializeField] private GameObject id;

    private bool isInvestigated = false;
    private Item stored_item = null;
    private int inv_id = 0;

    public void UpdateInfo(Item item, int i)
    {
        // Display image
        GameObject imageObject = transform.GetChild(0).gameObject;
        Image image = imageObject.GetComponent<Image>();
        image.sprite = item.icon;

        // Display 
        TextMeshProUGUI displayText = GetComponentInChildren<TextMeshProUGUI>();
        displayText.text = item.name;

        stored_item = item;
        
        // Modify the interactable of button
        InvestigateBtn.interactable = true;
        if (isInvestigated)
        {
            CheckBtn.interactable = true;
        }else CheckBtn.interactable = false;

        inv_id = i;
    }

    public void DisplayDetailInfo()
    {

        if (stored_item == null)
        {
            return;
        }
        id.name = inv_id.ToString(); 
        title.text = stored_item.name;
        DisplayImage.sprite = stored_item.icon;
        Description.text = stored_item.description;
    }
}
