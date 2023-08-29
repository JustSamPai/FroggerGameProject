using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFrogger
{
    Vector3 direction;
    ICommand _onCommand;
    public MoveFrogger(ICommand onCommand) {
        _onCommand = onCommand;

    }
    public void FroggerMove(){
        _onCommand.Execute();
    }

}
