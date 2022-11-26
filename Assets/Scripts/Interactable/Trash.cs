using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : BaseInteractable
{
    public GameManager gameManager;
    public override void InteractWithPlayer()
    {
        gameManager.point += 1;
        base.InteractWithPlayer();
    }
}
