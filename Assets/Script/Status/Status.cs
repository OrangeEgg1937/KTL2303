using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "Status", menuName = "Status", order = 1)]
[System.Serializable]
public class Status : ScriptableObject
{
    [Header("Status Information")]
    [SerializeField]
    public string statusName;
    [SerializeField]
    public string statusDescription;
    [SerializeField]
    [Tooltip("The status is hidden or not by default")]
    public bool isHiddenAtStart;
    [SerializeField]
    [Tooltip("The status is discover by player or not")]
    public bool isDiscover = false;

    [Header("Favorite Conditions")]
    [Tooltip("What conditions are favorable for this status?")]
    [SerializeField]
    public List<FavorableConditions> conditions; // Favorable conditions for this status
    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("The base discovery rate of this status")]
    public float discoveryRate;
    [SerializeField]
    [Range(0f, 1f)]
    [Tooltip("The percentage increase to the discovery rate of this status when the conditions are favorable")]
    public float bonusDiscoveryRate;
}
