using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethods
{
    public static Object Instantiate(this Object thisObj, Object original, Vector3 position, Quaternion rotation, Transform parent, Option option, DialogBox dialogBox)
    {
        GameObject optionBtn = Object.Instantiate(original, position, rotation, parent) as GameObject;
        OptionButton scr = optionBtn.GetComponent<OptionButton>();
        scr.OnCreate(option, dialogBox);
        return optionBtn;
    }
}

public class OptionButton : MonoBehaviour
{
    [SerializeField] private Button optionButton;
    [SerializeField] private TextMeshProUGUI optionText;
    public void OnCreate(Option option, DialogBox d_box)
    {
        // Set the button text
        optionText.text = option.content;

        // link the option to the dialog box
        optionButton.onClick.AddListener(() => d_box.ProcessOption(option));
    }
}
