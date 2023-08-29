using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    public string playerName;
    public int highScore;

    public PlayerProfile(string playerName, int highScore)
    {
        this.playerName = playerName;
        this.highScore = highScore;
    }
}
