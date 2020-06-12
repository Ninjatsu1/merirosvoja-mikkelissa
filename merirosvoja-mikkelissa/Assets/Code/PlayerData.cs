using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{
    public int health;
    public int numOfHearts;
    public PlayerData(Player player)
    {

        health = Health.health;
        numOfHearts = Health.numOfHearts;

    }

}
