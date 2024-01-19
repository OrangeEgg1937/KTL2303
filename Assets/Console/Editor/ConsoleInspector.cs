using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(DebugConsole))]
public class DebugConsoleInspector : Editor
{
    // The inspector
    VisualElement myInspector;

    // XML for the inspector
    public VisualTreeAsset m_InspectorXML;

    // The display scale mode setting visual element
    private VisualElement displayScaleModeSetting;

    private EnumField displayScale;

    // Display field for disaply scale
    private FloatField displayHeight;
    private FloatField displayWidth;

    public override VisualElement CreateInspectorGUI()
    {

        // Create a new VisualElement to be the root of inspector UI if it is null
        if (myInspector == null)
        {
            myInspector = new VisualElement();

            // Load from default reference
            m_InspectorXML.CloneTree(myInspector);

            // Set the field
            displayHeight = new FloatField("Height");
            displayWidth = new FloatField("Width");
            displayHeight.bindingPath = "m_displayHeight";
            displayWidth.bindingPath = "m_displayWidth";

            // Get the setting
            displayScaleModeSetting = myInspector.Q("Scale");
            displayScale = myInspector.Q<EnumField>("DisplayScale").GetFirstOfType<EnumField>();

            // init the value
            DisplayScaleModeSettingMenu((ConsoleScaleMode)displayScale.value);
            Debug.Log((ConsoleScaleMode)displayScale.value + " " + displayScale.text);

            // Add the callback function
            displayScale.RegisterValueChangedCallback(DisplayScaleModeSettingMenuCallback);
        }

        // Return the finished inspector UI
        return myInspector;
    }


    private void DisplayScaleModeSettingMenuCallback(ChangeEvent<Enum> evt)
    {
        Debug.Log((ConsoleScaleMode)displayScale.value + " " + displayScale.text);
        // Bind the variables base on the setting
        DisplayScaleModeSettingMenu((ConsoleScaleMode)evt.newValue);
    }

    private void DisplayScaleModeSettingMenu(ConsoleScaleMode mode)
    {
        switch (mode)
        {
            case ConsoleScaleMode.Screen: ScreenMode(); break;
            case ConsoleScaleMode.Custom: CustomMode(); break;
            default: break;
        }
    }

    private void CustomMode()
    {
        displayScaleModeSetting.Add(displayWidth);
        displayScaleModeSetting.Add(displayHeight);
    }

    private void ScreenMode()
    {
        displayScaleModeSetting.Clear();
    }

}