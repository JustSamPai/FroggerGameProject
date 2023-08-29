using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUIHandler : MonoBehaviour
{
    public MainMenuState mainMenuState;
    public InputField playerNameInputField;
    public Dropdown profileDropdown;

    public void OnCreateProfileButtonClicked()
    {
        string playerName = playerNameInputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            mainMenuState.CreateProfile(playerName);
            UpdateProfileDropdown();
            playerNameInputField.text = "";
        }
    }

    public void OnProfileSelected()
    {
        mainMenuState.SelectProfile(profileDropdown.value);
    }

    private void UpdateProfileDropdown()
    {
        profileDropdown.ClearOptions();
        List<string> profileNames = new List<string>();

        foreach (var profile in mainMenuState.profileManager.playerProfiles)
        {
            profileNames.Add(profile.playerName);
        }

        profileDropdown.AddOptions(profileNames);
    }

    private void Start()
    {
        UpdateProfileDropdown();
    }
}
