using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public MainMenuState mainMenuState;
    public OptionsMenuState optionsMenuState;
    private MenuState currentState;
    private void Start()
    {
        // Set initial state to main menu state
        currentState = mainMenuState;
        currentState.EnterState();
    }

    private void Update()
    {
        // Update current state
        currentState.UpdateState();
    }

    public void SwitchToMainMenu()
    {
        // Exit current state and switch to main menu state
        currentState.ExitState();
        currentState = mainMenuState;
        currentState.EnterState();
    }

    public void SwitchToOptionsMenu()
    {
        // Exit current state and switch to options menu state
        currentState.ExitState();
        currentState = optionsMenuState;
        currentState.EnterState();
        
    }

 
}
