using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum DialogType
{
    Normal = 0,
    ContainsRequirement = 1,
    ContainsOption = 2
}

[System.Serializable]
public class Option
{
    public string content;

    [Header("Optioninal pre-requirement")]
    public bool containRequirement = false;
    public List<Trigger> Requirement;

    public Dialog NextDialog;
    
    // Check the option is available to be selected or not
    public bool isOptionAvailable(List<Trigger> playerTrigger)
    {
        if (containRequirement)
        {
            // if the player trigger contains the pre-trigger, return true
            foreach (var trigger in Requirement)
            {
                if (playerTrigger.Contains(trigger))
                {
                    return true;
                }
            }
            // player trigger does not contain the pre-trigger, return false
            return false;
        }
        else
        {
            return true;
        }
    }
}

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog", order = 1)]
[System.Serializable]
public class Dialog: ScriptableObject
{
    [TextAreaAttribute]
    public string content;

    [Header("Reward")]
    public List<Trigger> Reward;

    [Header("Dialog Setting")]
    public DialogType dialogType = DialogType.Normal;

    [Header("Dialog with option")]
    [SerializeField] private Option[] option;

    [Header("Dialog without option")]
    public List<Trigger> Requirement;
    public Dialog NextDialog;


    // Process the current dialog
    public bool ProcessDialog(Option userOption, ref Dialog nextDialog)
    {
        if (dialogType == DialogType.Normal)
        {
            return true;
        }

        if (dialogType == DialogType.ContainsOption)
        {
            // Check the option
            foreach (var op in option)
            {
                if (op == userOption)
                {
                    nextDialog = op.NextDialog;
                    return true;
                }
            }
        }

        return false;
    }

    public bool ProcessDialog(List<Trigger> playerTrigger)
    {
        if (dialogType == DialogType.Normal)
        {
            return true;
        }

        if (dialogType == DialogType.ContainsRequirement)
        {
            // Check the requirement
            foreach (var trigger in Requirement)
            {
                if (!playerTrigger.Contains(trigger))
                {
                    return false;
                }
            }
            return true;
        }

        return false;
    }

    // Return all the available options
    public List<Option> DialogOption(List<Trigger> playerTrigger)
    {
        if (dialogType == DialogType.Normal) return null;

        // Copy the current dialog option
        List<Option> availableOption = new List<Option>();

        // Check the option is available or not
        foreach (var op in option)
        {
            if (op.isOptionAvailable(playerTrigger))
            {
                availableOption.Add(op);
            }
        }

        // Return the available option
        return availableOption;
    }
}

[CreateAssetMenu(fileName = "Scenario", menuName = "Scenario", order = 1)]
[System.Serializable]
public class Scenario: ScriptableObject
{
    [Header("Starting Dialog")]
    [SerializeField] private Dialog StartingDialog;

    [SerializeField] private Dialog currentDialog;

    public void ResetScenario()
    {
        currentDialog = StartingDialog;
    }

    public void ProcessDialog(Option userOption, ref List<Trigger> playerTrigger)
    {
        // if there is no next dialog, reutrn
        if (currentDialog == null || currentDialog.NextDialog == null) return;

        // Check the current dialog type
        if (currentDialog.dialogType == DialogType.Normal)
        {
            // Move to the next dialog
            currentDialog = currentDialog.NextDialog;
        }

        if (currentDialog.dialogType == DialogType.ContainsRequirement)
        {
            // Check the requirement
            if (currentDialog.ProcessDialog(playerTrigger))
            {
                // Move to the next dialog
                currentDialog = currentDialog.NextDialog;
            }
        }

        if (currentDialog.dialogType == DialogType.ContainsOption)
        {
            // Check the option
            if (currentDialog.ProcessDialog(userOption,ref currentDialog))
            {
                return;
            }
        }
    }

    public List<Option> GetCurrentDialogOption(List<Trigger> playerTrigger)
    {
        return currentDialog.DialogOption(playerTrigger);
    }

    public string GetCurrentDialogContent()
    {
        return currentDialog.content;
    }

    public Dialog GetCurrentDialog()
    {
        return currentDialog;
    }
}