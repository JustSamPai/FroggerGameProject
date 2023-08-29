using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : MenuState
{
    public ProfileManager profileManager;

    public AudioManager audioManager;
    public AudioClip audioClip;

    bool loadlevel = false;
    public override void EnterState()
    {
        // Implement game start logic

        Debug.Log("changing State");
        if(!loadlevel){
            audioManager.playSound();
        }
        
        UpdateState();
    }

    public override void UpdateState()
    {
        // Implement game start update logic
        if(loadlevel){
            ExitState();
        }
    }

    public override void ExitState()
    {
        // Implement game start exit logic
        audioManager.stopSound();
        SceneManager.LoadScene("Level_1");
        loadlevel = false;
    }
    public void LoadLevel1()
    {
        loadlevel = true;

        // Load Level 1 scene
        // SceneManager.LoadScene("Level_1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadAchievements(){
        SceneManager.LoadScene("Achivements");
    }


    public void CreateProfile(string playerName)
    {
        profileManager.AddProfile(playerName);
    }

    public void SelectProfile(int profileIndex)
    {
        profileManager.SelectProfile(profileIndex);
    }

}
