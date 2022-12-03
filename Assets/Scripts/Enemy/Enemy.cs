using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Player player;

    [Header("Enemy Attack")]
    public bool canShoot; // if true => enemy can shoot
    public bool canDamage; // if true => player touching affecting damage
    public Transform shootingPoint;
    public GameObject bulletPrefabLeft;
    public GameObject bulletPrefabRight;
    public float BulletTimer;
    public float ShootingDelay;
    public float DamageTimer;
    public float TouchDelay;

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
                if(transform.localScale.x == 1)
                    Instantiate(bulletPrefabLeft, shootingPoint.position, transform.rotation);

                if (transform.localScale.x == -1)
                    Instantiate(bulletPrefabRight, shootingPoint.position, transform.rotation);

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canDamage)
            {
                DamageTimer += Time.deltaTime;

                if (DamageTimer > TouchDelay)
                {
                    player.ChangeHealth(-2);

                    DamageTimer = 0;
                }
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

}
