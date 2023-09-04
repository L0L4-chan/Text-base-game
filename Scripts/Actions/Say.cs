using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string input)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, input))
        {
            return;

        }
        else
        {
            controller.currentText.text = "No respond";
        }

    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "say", noun))
                    {
                        return true;
                    }
                }else{
                    controller.currentText.text = "The " + item.itemName + " doesn´t respond";
                    return true;

                }
            }
        }
        return false;
    }
}
