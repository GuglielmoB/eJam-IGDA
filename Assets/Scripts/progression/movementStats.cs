using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementStats : MonoBehaviour 
{
    Dictionary <string, int> movementStat;

    private void Start() 
    {
        movementStat = new Dictionary<string, int>()
        {
            {"wallSlideGrip", 0},              // The time in which the player can stick to a wall before beginning to slide down
        };

        print("test");
    }

    // Gets the value of the given stat, self explanatory
    public int GetStat(string statName)
    {
        return movementStat[statName];
    }

    // Sets the value of a stat. This probably won't be used as IncrementStat will be better suited for our needs, 
    //    but it's good to have anyway just in case.
    public void SetStat(string statName, int value)
    {
        movementStat[statName] = value;
    }

    // Increments the value of a certain stat, with the base incrementation being +1. Most actions will likely reward
    //    one point of progression each time you do them, so we have this +1 base incrementation: but we keep the ability
    //    to set it custom just in case.
    public void IncrementStat(string statName, int value = 1)
    {
        movementStat[statName] += value;
    }
}