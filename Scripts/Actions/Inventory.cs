using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController controller, string input)
    {
        if(controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing.";
            return;
        }

        string result = "You have a ";
        bool first = true;
        foreach(Item item in controller.player.inventory)
        {
            if (!first)
            {
                result += " and ";
            }
            result += item.itemName;
            first = false;
        }
        result += "\n";
        controller.currentText.text = result;
    }
}
