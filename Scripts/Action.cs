using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Action : ScriptableObject
{
    public string keyword;

    //method that will act on the command word

    public abstract void RespondToInput(GameController controller, string verb);

}
