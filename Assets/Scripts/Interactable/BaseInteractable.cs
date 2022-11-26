using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InteractWithPlayer();
        }
    }

    private void OnDestroy()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void InteractWithPlayer()
    {
        Destroy(this.gameObject);
    }
}
