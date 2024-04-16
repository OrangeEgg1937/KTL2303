using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmScript : MonoBehaviour
{
    [SerializeField] private Slider InvestSlider;
    [SerializeField] private Slider InterroSlider;
    [SerializeField] private Slider ActionSlider;
    [SerializeField] private GameObject WarningWindow;
    [SerializeField] private TextMeshProUGUI WarningText;
    [SerializeField] private TextMeshProUGUI TotalPointText;
    [SerializeField] public int MaxPoint = 40;
    private int Overall;
    //calculate total point, start the game if point = Maxpoint
    public void PlayGame()
    {
        
        if (Overall != MaxPoint) {
            WarningWindow.SetActive(true);
            WarningText.text = "There should be at least " + MaxPoint + " point in total";
            
        }
        else {

            DataTransfer.investigation = (int)InvestSlider.value;
            DataTransfer.interrogation = (int)InterroSlider.value;
            DataTransfer.action = (int)ActionSlider.value;
            SceneManager.LoadScene("SampleScene");
        }
        
    }
    //show total point
    void Update()
    {
        Overall = (int)(InvestSlider.value + InterroSlider.value + ActionSlider.value);
        TotalPointText.text = "Total Point: " + Overall.ToString();
    }
}
