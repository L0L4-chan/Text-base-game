using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public string locationName;

    [TextArea]
    [Multiline]
    public string description;

    [HideInInspector]
    public string _description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //to return a string with all the connections
    public string GetConnectionsText()
    {
        /*
        if (conections == null)     
        {
            return "not conecctions";
        }else
        {
            string connectionsAvailables;
            for (int i = 0;i<= conections.size; i ++)
            {
                if (connections[i].connectionEnabled) 
                { connectionsAvailables += connections[i].connectionName;
                  connectionsAvailables += ": ";
                  connectionsAvailables += connections[i].description;
                  connectionsAvailables += "\n";

                }
            }
            return connectionsAvailables;
        }
        */
        string result = "";
        foreach (Connection connection in connections)
        {
            if (connection.connectionEnabled)
            {
                result += connection.description + " ";
            }
        }
        return result;
    }

    public Connection GetConnection(string connectionName)
    {
        foreach(Connection conecction in connections)
        {

            if (conecction.connectionName.ToLower() == connectionName.ToLower())
            {
                return conecction;
            }
            
        }
        return null;
    }

    public string GetItemText()
    {
        if (items.Count == 0) 
        {
            return "";
        }
        string result = "You see ";
        bool first = true;
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first)
                {
                    result += " and ";
                }
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }


    internal bool HasItem(Item item)
    {
        foreach (Item itm in items)
        {
            if (itm == item &&  itm.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }
}
