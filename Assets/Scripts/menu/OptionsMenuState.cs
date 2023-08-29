using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuState : MenuState
{
    public override void EnterState()
    {
        // Implement game start logic
        Debug.Log("changing State");
        
        UpdateState();
    }

    public override void UpdateState()
    {
        // Implement game start update logic
    }

    public override void ExitState()
    {
        // Implement game start exit logic
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options_Menu");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
