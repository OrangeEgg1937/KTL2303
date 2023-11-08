using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "Status", menuName = "Status", order = 1)]
[System.Serializable]
public class Status : ScriptableObject
{
    [HeaderAttribute("Status Information")]
    [SerializeField]
    public string statusName;
    [SerializeField]
    public string statusDescription;
    [SerializeField]
    [Tooltip("The status is hidden or not by default")]
    public bool isHiddenAtStart; 

    [HeaderAttribute("Favorite Conditions")]
    [ToolTipAttribute("What conditions are favorable for this status?")]
    [SerializeField]
    public FavorableConditions conditions[]; // Favorable conditions for this status
    [SerializeField]
    [Range(0f, 1f)]
    [ToolTipAttribute("The base discovery rate of this status")]
    public float discoveryRate;
    [SerializeField]
    [Range(0f, 1f)]
    [ToolTipAttribute("The percentage increase to the discovery rate of this status when the conditions are favorable")]
    public float bonusDiscoveryRate;
}
