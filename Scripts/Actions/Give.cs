using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Action
{
    public override void RespondToInput(GameController controller, string input)
    {
        if(controller.player.GetHasItemByName(input))
        {
            if (GiveToItem(controller, controller.player.currentLocation.items, input))
            {
              // controller.player.inventary.Remove(item)
                return;

            }
            else
            {
                controller.currentText.text = "Nothing take the " + input;
                return;
            }

        }
        else
        {
            controller.currentText.text = "You don´t have " + input + "to give.";
        }
    }
        private bool GiveToItem(GameController controller, List<Item> items, string noun)
        {
            foreach (Item item in items)
            {
                if (item.itemEnabled)
                {

                    if (controller.player.CanGiveItem(controller, item))
                    {
                        if (item.InteractWith(controller, "give", noun))
                        {
                            return true;
                        }
                    }
                    controller.currentText.text = "The " + noun.ToLower() + " doesn´t respond";
                    return true;

                }
            }
            return false;
        }

    
}
