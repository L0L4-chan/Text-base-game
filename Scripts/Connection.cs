using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Connection : MonoBehaviour
{
  public string connectionName;

    [TextArea]
    [Multiline]
    public string description;

    [HideInInspector]
    public string _description;


    public Locations location;

  public bool connectionEnabled;
}
