using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Player player;

    [Header("Enemy Attack")]
    public bool canShoot; // if true => enemy can attack player
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float BulletTimer;
    public float ShootingDelay;

    void Start()
    {
        health = Mathf.Clamp(maxHealth, 0, maxHealth);
    }

    void Update()
    {
        if(canShoot)
        {
            BulletTimer += Time.deltaTime;

            if(BulletTimer > ShootingDelay)
            {
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                BulletTimer = 0;
            }
        }    
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
