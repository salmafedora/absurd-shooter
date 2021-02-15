using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    CompleteProject.PlayerMovement playerMovement;
    float h, v;
    private CompleteProject.PlayerMovement playerMovement1;

    public MoveCommand(CompleteProject.PlayerMovement _playerMovement, float _h, float _v)
    {
        this.playerMovement = _playerMovement;
        this.h = _h;
        this.v = _v;
    }


    //Trigger perintah movement
    public override void Execute()
    {
        playerMovement.Move(h, v);
 
        playerMovement.Animating(h, v);
    }

    public override void UnExecute()
    {
        
        playerMovement.Move(-h, -v);
        
        playerMovement.Animating(h, v);
    }
}
