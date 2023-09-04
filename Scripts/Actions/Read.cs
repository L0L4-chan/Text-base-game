using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //use if the item is in the room
        if (ReadItem(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        //use if the item is in inventory
        if (ReadItem(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "There is no " + noun.ToLower();

    }
    //Method to check for a Item
    private bool ReadItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.CanReadItem(controller, item))
                {


                    if (item.InteractWith(controller, "read"))
                    {
                        return true;
                    }
                }
                controller.currentText.text = "The " + noun.ToLower() + " does nothing";
                return true;
            }
        }
        return false;
    }

}

