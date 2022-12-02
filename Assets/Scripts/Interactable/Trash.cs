using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : BaseInteractable
{
    public GameManager gameManager;

    public SpriteRenderer trashSprite;
    public Sprite[] sprites;

    private void Start()
    {
        trashSprite.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public override void InteractWithPlayer()
    {
        gameManager.coinCollected += 1;
        base.InteractWithPlayer();
    }
}
