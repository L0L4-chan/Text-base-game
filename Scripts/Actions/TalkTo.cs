using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameController controller, string input)
    {
        if (TalkToItem(controller, controller.player.currentLocation.items, input))
        {
            return;

        }
        else
        {
            controller.currentText.text = "There is no " + input + " here.";
        }

    }

    private bool TalkToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (item.itemName.ToLower() == noun.ToLower())
                {
                    if (controller.player.CanTalkToItem(controller, item))
                    {


                        if (item.InteractWith(controller, "talkTo"))
                        {
                            return true;
                        }
                    }
                    controller.currentText.text = "The " + noun.ToLower() + " doesn´t respond";
                    return true;
                }
            }
        }
        return false;
    }
}
