using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public TimeManager timeManager;
    public Frogger _frogger;
    MoveFrogger _moveFrogger;
    MoveList _moveList;
     Vector3 direction;
    public GameManager gameManager;
    
    void Start()
    {
        _frogger = GetComponent<Frogger>();
        _moveList = new MoveList();
        // ICommand moveCommand = new MoveCommand(_frogger, direction);
        // _moveFrogger = new MoveFrogger(moveCommand);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (gameManager.allowInput){
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                ICommand moveCommand = new MoveCommand(_frogger, Vector3.up);
                // ICommand storedCommand = new MoveCommand(_frogger, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                _moveList.AddCommand(moveCommand);
                // _moveFrogger = new MoveFrogger(moveCommand);
                // _moveFrogger.FroggerMove();
                // transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                // Move(Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ICommand moveCommand = new MoveCommand(_frogger, Vector3.down);
                // ICommand storedCommand = new MoveCommand(_frogger, Vector3.down);
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                _moveList.AddCommand(moveCommand);
                // _moveFrogger = new MoveFrogger(moveCommand);
                // _moveFrogger.FroggerMove();
                // transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                // Move(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ICommand moveCommand = new MoveCommand(_frogger, Vector3.left);
                // ICommand storedCommand = new MoveCommand(_frogger, Vector3.left);
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                _moveList.AddCommand(moveCommand);
                // _moveFrogger = new MoveFrogger(moveCommand);
                // _moveFrogger.FroggerMove();
                // transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                // Move(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ICommand moveCommand = new MoveCommand(_frogger, Vector3.right);
                // ICommand storedCommand = new MoveCommand(_frogger, Vector3.right);
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                _moveList.AddCommand(moveCommand);
                // _moveFrogger = new MoveFrogger(moveCommand);
                // _moveFrogger.FroggerMove();
                // transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                // Move(Vector3.right);
            }
            else if(Input.GetKeyDown(KeyCode.M)){
                timeManager.BulletTime();
            }

            else if (Input.GetKeyDown(KeyCode.Z)){
                _moveList.UndoCommand();
            }
            
        }
        }
    }
}
