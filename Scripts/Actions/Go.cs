using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Action
{

    public override void RespondToInput(GameController controller, string input)
    {
        if (controller.player.ChangeLocation(controller, input))   
        {
            controller.DisplayLocation();
        }
        else
        {
            controller.currentText.text = "You can´t go that way.";
        }
    }
}