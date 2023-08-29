using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveList
{
   Stack<ICommand> _commandList;

    public MoveList(){
        _commandList = new Stack<ICommand>();
    }
    public void AddCommand(ICommand newCommand){
        newCommand.Execute();
        _commandList.Push(newCommand);
    } 
    
    public void UndoCommand(){
        if(_commandList.Count > 0 ){
            ICommand lastestCommand = _commandList.Pop();
            
            lastestCommand.Undo();
        }
    }
}
