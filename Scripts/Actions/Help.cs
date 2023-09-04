using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string input)
    {


        controller.currentText.text = "<color=#18C899>" + "Type a verb followed by a noun (e.g. \"go north\")" + "</color>";
        controller.currentText.text += "<color=#18C899>" + "\nAllowed verbs: \nGo, Examine, Read, Get, Help, Inventory, Say, TalkTo, Use. " + "</color>";
    }
}
