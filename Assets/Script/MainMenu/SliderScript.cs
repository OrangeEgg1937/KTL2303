using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _silder;
    [SerializeField] private TextMeshProUGUI value;// Moving speed of the player
    // Start is called before the first frame update
    void Start()
    {
        _silder.onValueChanged.AddListener((v) =>
        {
            value.text = v.ToString("0");
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
