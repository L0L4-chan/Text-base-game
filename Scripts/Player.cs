using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Locations currentLocation;

    public List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool ChangeLocation(GameController gamecontroller, string connection)
    {
        Connection given = currentLocation.GetConnection(connection);
        if (given != null)
        {
            if (given.connectionEnabled)
            {
                currentLocation = given.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }
        else
        {
            if (HasItem(item.targetItem))
            {
                return true;
            }

            if (currentLocation.HasItem(item.targetItem)) 
            {
                return true;
            }

        }
        return false;
    }

    private bool HasItem(Item item)
    {
        foreach (Item itm in inventory)
        {
            if (itm == item &&  itm.itemEnabled)
            {
                    return true;
            }
        }
        return false;
    }

 
    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalk;
    }

    internal bool CanGiveItem(GameController controller, Item item)
    {
        return item.playerCanGive;
    }

    public bool GetHasItemByName(string noun)
    {
        foreach (Item itm in inventory)
        {
            if (itm.itemName.ToLower() == noun.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller, Locations destination)
    {
        currentLocation = destination;
    }


    internal bool CanReadItem(GameController controller, Item item)
    {
        return item.playerCanRead;
    }
}


