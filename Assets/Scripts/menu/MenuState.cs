using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuState : MonoBehaviour 
{
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
}
