using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactions 
{
    public Action action;

    [TextArea]
    [Multiline]
    public string response;

    [HideInInspector]
    public string _response;

    public string textToMatch;

    public List<Item> itemsToDisable = new List<Item> ();
    public List<Item> itemsToEnable = new List<Item>();

    public List<Connection> connectionToDisable = new List<Connection>();
    public List<Connection> connectionToEnable = new List<Connection>();

    public Locations teleportLocation;
}
