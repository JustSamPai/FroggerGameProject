using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    Vector3 direction;
    Frogger _frogger;

    Vector3 _previousPosition;

    public MoveCommand(Frogger frogger, Vector3 direction){
        _frogger = frogger;
        this.direction = direction;
        _previousPosition = frogger.transform.position;
        

    }
    public void Execute(){
        _frogger.Move(direction);
    }

    public void Undo(){
        _frogger.transform.position = _previousPosition;

    }
}
