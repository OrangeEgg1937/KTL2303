using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.InputSystem;

public class DialogBox : MonoBehaviour
{
    public GameObject DialogFrame;
    public TextMeshProUGUI NameDisplay;
    public TextMeshProUGUI textDisplay;
    public string[] line;
    public string Name;
    public float textSpeed;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        DialogFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            //if all text of current line are finished, go other line
            if (textDisplay.text == line[index])
            {
                NextLine();
            }
            //immediately finish the line
            else 
            {
                StopAllCoroutines();
                textDisplay.text = line[index];
            }
        }
    }

    public void startdDialogue()
    {
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
    }
    //go to display next line
    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else 
        {
            DialogFrame.SetActive(false);
        }
    }
}
