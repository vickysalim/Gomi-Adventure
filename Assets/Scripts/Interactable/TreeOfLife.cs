using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : BaseInteractable
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public Player player;

    private void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public override void InteractWithPlayer()
    {
        spriteRenderer.sprite = newSprite;

        Vector3 newRespawnPoint = new Vector3(this.transform.position.x, player.transform.position.y, player.transform.position.z);
        player.SetRespawnPoint(newRespawnPoint);
    }
}
