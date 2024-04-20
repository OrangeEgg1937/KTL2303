using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

/*// Process the onclick event when user click the option
public delegate void OnClickOption(Option option);
*/
public class DialogBox : MonoBehaviour
{
    public GameFlow gameflow;
    public GameObject DialogFrame;
    public GameObject OptionList;
    public TextMeshProUGUI NameDisplay;
    public TextMeshProUGUI textDisplay;
    public string[] line;
    public string Name;
    public float textSpeed;
    public GameObject Player;

    [SerializeField]
    private GameObject OptionPrefab;
    [SerializeField]
    private Character m_character;
    private Scenario m_currentScenario;


    private int index;




    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {

    }


    private void OnDisable()
    {
        print("I am disabled");
        // Update the character scenario
        // m_character.UpdateScenario(m_currentScenario);
    }

    private void processTextDisplay()
    {
        StopAllCoroutines();
        index = 0;
        NameDisplay.text = Name;
        textDisplay.text = string.Empty;
        DialogFrame.SetActive(true);
        StartCoroutine(TypeLine());
    }

    // type words one by one
    IEnumerator TypeLine() 
    { 
        foreach(char c in line[index].ToCharArray())
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        NextLine();
    }

    // go to display next line
    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textDisplay.text += "\n";
            StartCoroutine(TypeLine());
        }
    }

    // process the dialog option
    public void ProcessOption(Option option)
    {
        print(option.content);
        //triggerred by Samentha, activate hidden dialog of Lisa
        if (option.content == "who is killer?")
        { 
            if (gameflow.killer == 2)
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponFalseRevealTrigger(PA)"));
            else
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponRevealTrigger(PA)"));
        }
        //triggerred by Mark, activate hidden dialog of Samentha
        else if (option.content == "who is killer??")
        {
            if (gameflow.killer == 0)
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponFalseRevealTrigger(Wife)"));
            else
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponRevealTrigger(Wife)"));
        }
        //triggerred by Lisa, activate hidden dialog of Mark
        else if (option.content == "who is killer???")
        {
            if (gameflow.killer == 1)
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponFalseRevealTrigger(Mark)"));
            else
                Player.GetComponent<Player>().AddTrigger(Resources.Load<Trigger>("WeaponRevealTrigger(Mark)"));
        }


        List<Trigger> playerTrigger = Player.GetComponent<Player>().GetPlayerTriggerList();
        m_currentScenario.ProcessDialog(option, ref playerTrigger);
        UpdateScreen();
    }

    private void UpdateScreen()
    {        
        // Clear the option list
        foreach (Transform child in OptionList.transform)
        {
            Destroy(child.gameObject);
        }

        // Get the current dialog content
        Dialog currentDialog = m_currentScenario.GetCurrentDialog();

        // Set the dialog box name and content
        Name = m_character.name;
        line = currentDialog.content.Split('\n');

        // Get the player trigger list
        List<Trigger> playerTrigger = Player.GetComponent<Player>().GetPlayerTriggerList();

        processTextDisplay();

        // Check the current dialog type
        if (currentDialog.dialogType == DialogType.Normal || currentDialog.dialogType == DialogType.ContainsRequirement)
        {
            return;
        }

        // Get the current dialog option
        List<Option> options = m_currentScenario.GetCurrentDialogOption(playerTrigger);

        print("Current dialog option: " + options.Count);

        // Create the option button if there is any option
        if (options != null)
        {
            foreach (var op in options)
            {
                OptionList.Instantiate(OptionPrefab, Vector3.zero, Quaternion.identity, OptionList.transform, op, this);
            }
        }
    }

    public void loadCurrentScenario(Scenario scenario, GameObject character)
    {
        // Set the current scenario and current character
        scenario.ResetScenario();
        m_currentScenario = scenario;
        m_character = character.GetComponent<Character>();

        UpdateScreen();
    }

}
