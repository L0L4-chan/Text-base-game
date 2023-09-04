using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{


    public override void RespondToInput(GameController controller, string noun)
    {
        //check if the item is in the room
        if (CheckItem(controller, controller.player.currentLocation.items, noun)) 
        {
            return;
        }

        //check if the item is in inventory
        if (CheckItem(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "You cant see a " + noun;

    }


    //Method to check for a Item
    private bool CheckItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items) 
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (item.InteractWith(controller, "examine"))
                {
                    return true;
                }
                
                controller.currentText.text = "You see " + item.description;
                return true;
            }
        }
        return false;
    }


}
