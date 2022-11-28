using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Player player;

    void Start()
    {
        health = Mathf.Clamp(maxHealth, 0, maxHealth);
    }

    private void OnDestroy()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ChangeHealth(-player.damage);
            Debug.Log("Enemy got hit");

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

}
