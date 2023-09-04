using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string input)
    {
        foreach(Item item in controller.player.currentLocation.items) 
        {
            if (item.itemEnabled && item.itemName.ToLower() == input.ToLower()) 
            {   
                if (item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currentLocation.items.Remove(item);
                    controller.currentText.text = "You take the " + input + "\n";
                    return;
                }
            
            }
        
        }
        controller.currentText.text = "You can´t get that.\n";
    }
}
