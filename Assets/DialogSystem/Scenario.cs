using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Scenario", menuName = "Scenario", order = 1)]
[System.Serializable]
public class Scenario : ScriptableObject
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
            if (currentDialog.ProcessDialog(userOption, ref currentDialog))
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