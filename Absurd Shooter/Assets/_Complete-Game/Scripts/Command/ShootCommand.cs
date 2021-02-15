using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootCommand : Command 
{

    CompleteProject.PlayerShooting playerShooting;

    public ShootCommand(CompleteProject.PlayerShooting _playerShooting)
    {
        playerShooting = _playerShooting;
    }

    public override void Execute()
    {

        playerShooting.Shoot();
    }

    public override void UnExecute()
    {

    }
}

