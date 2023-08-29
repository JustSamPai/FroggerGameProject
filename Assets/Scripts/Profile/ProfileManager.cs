using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    public List<PlayerProfile> playerProfiles;

    private void Awake()
    {
        LoadProfiles();
    }

    public void SaveProfiles()
    {
        for (int i = 0; i < playerProfiles.Count; i++)
        {
            PlayerPrefs.SetString("PlayerName_" + i, playerProfiles[i].playerName);
            PlayerPrefs.SetInt("HighScore_" + i, playerProfiles[i].highScore);
        }
        PlayerPrefs.SetInt("ProfileCount", playerProfiles.Count);
        PlayerPrefs.Save();
    }

    public void LoadProfiles()
    {
        playerProfiles = new List<PlayerProfile>();
        int profileCount = PlayerPrefs.GetInt("ProfileCount", 0);

        for (int i = 0; i < profileCount; i++)
        {
            string playerName = PlayerPrefs.GetString("PlayerName_" + i, "Player");
            int highScore = PlayerPrefs.GetInt("HighScore_" + i, 0);
            playerProfiles.Add(new PlayerProfile(playerName, highScore));
        }
    }

    public void AddProfile(string playerName)
    {
        playerProfiles.Add(new PlayerProfile(playerName, 0));
        SaveProfiles();
    }

    public void SelectProfile(int index)
    {
        // Do something with the selected profile, e.g., store it in a variable
    }
}
