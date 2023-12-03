using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionValueDisplay : MonoBehaviour
{
    [SerializeField] private Player player;

    private TextMeshProUGUI currentText;

    private void Awake()
    {
        currentText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentText.SetText(player.Action.ToString());
    }
}
