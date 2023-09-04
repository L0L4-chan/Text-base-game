using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;

    public Text logText;

    public Text currentText;

    public Action[] actions; 

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //to display the actual location
    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += "\n";
        description += player.currentLocation.GetItemText();
        if (additive)
        {
            currentText.text = currentText.text + "\n" + description;
        }
        else
        {
            currentText.text = description;
        }
    }

    //event calls
    public void TextEntered()
    {
       // Debug.Log("text entered");
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();


    }

    //update current text

    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";

        logText.text += "<color=#18C899>" + textEntryField.text + "</color>";
    }
    // process the user input
    public void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);

        foreach (Action action in actions) { 
        
        if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "<color=#18C899>"+"Nothing happens! (having trouble? type Help)" + "</color>";


    }


}
