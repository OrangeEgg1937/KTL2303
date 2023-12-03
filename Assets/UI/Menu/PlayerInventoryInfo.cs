using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryInfo : MonoBehaviour, IPlaneDisplay
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image DisplayImage;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private Button InvestigateBtn;
    [SerializeField] private Button CheckBtn;

    [Header("Default")]
    [SerializeField] private Sprite DefaultImg;

    public void DisplayInfo(int id)
    {
        if (id != 2)
        {
            title.text = "";
            DisplayImage.sprite = DefaultImg;
            Description.text = "";
            InvestigateBtn.interactable = false;
            CheckBtn.interactable = false;

            gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
