using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType
{
    NONE = 0,
    TRIGGER_LIST = 1,
    TRIGGER_BT_ITEM = 2,
    BOTH = 3
}

// Create the object status
[CreateAssetMenu(fileName = "Trigger", menuName = "Trigger", order = 1)]
[System.Serializable]
public class Trigger : ScriptableObject
{
    // Character attributes
    [Header("Trigger information")]
    [SerializeField] public string TriggerName;
    [SerializeField] public string TriggerDescription;

    [Header("Trigger status")]
    [SerializeField] public bool Switches = false;

    [Header("Trigger data")]
    [SerializeField] public List<dynamic> Data;

    [Header("Trigger Pre-requirement")]
    [SerializeField] public TriggerType RequirementType = TriggerType.NONE;
    [SerializeField] public HashSet<Trigger> PreRequirement = new HashSet<Trigger>();
    
    // Check the current trigger is going on or off
    public void CheckTrigger(List<Trigger> currTrigger)
    {
        // Check the trigger type
        if (RequirementType == TriggerType.NONE) { return; }

        if (RequirementType == TriggerType.TRIGGER_LIST)
        {

        }
    }
}
