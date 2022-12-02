using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : BaseInteractable
{
    public GameManager gameManager;
    public override void InteractWithPlayer()
    {
        gameManager.FinishStage();
    }
}
