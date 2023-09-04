using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    [Multiline]
    public string description;

    [HideInInspector]
    public string _description;

    public bool itemEnabled;

    public bool playerCanTake;

    public bool playerCanTalk;

    public bool playerCanGive;

    public bool playerCanRead;

    public Interactions[] interactions;

    public Item targetItem = null;

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "") 
    {
        foreach(Interactions interaction in interactions) 
        {
            if (interaction.action.keyword.ToLower() == actionKeyword.ToLower())
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                {
                    continue;
                }
                foreach (Item disableItem in interaction.itemsToDisable)
                {
                    disableItem.itemEnabled = false;
                }

                foreach (Item enableItem in interaction.itemsToEnable)
                {
                    enableItem.itemEnabled = true;
                }

                foreach (Connection disableConnection in interaction.connectionToDisable)
                {
                    disableConnection.connectionEnabled = false;
                }

                foreach (Connection enableConnection in interaction.connectionToEnable)
                {
                    enableConnection.connectionEnabled = true;
                }
                if(interaction.teleportLocation != null)
                {
                    controller.player.Teleport(controller, interaction.teleportLocation);
                }
                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);

                return true;
                 
            }
        
        }
        return false;
    }


}
