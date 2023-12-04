using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StatusName;
    [SerializeField] private TextMeshProUGUI StatusDetail;

    public string statusTitle;
    public string description;

    void OnEnable()
    {
        StatusName.text = statusTitle;
        StatusDetail.text = description;
    }

    private void OnDisable()
    {
        StatusName.text = "";
        StatusDetail.text = "";
    }
}
