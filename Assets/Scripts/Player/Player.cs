using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform shootingPoint;

    public GameObject bulletPrefab;
    [SerializeField] Vector3 respawnPoint;

    [Header("Stats")]
    public int playerLife = 3;
    public int maxHealth = 100;
    public int health;
    public int damage = 1;

    [Header("Audios")]
    public AudioSource playerSFX;
    public AudioClip attackAudio;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = this.transform.position;

        int maxHealthPrefs = 90 + (10 * PlayerPrefs.GetInt("StatsHealth", 1));
        maxHealth = maxHealthPrefs;
        health = Mathf.Clamp(maxHealth, 0, maxHealth);

        int damagePrefs = PlayerPrefs.GetInt("StatsDamage", 1);
        damage = damagePrefs;

        int playerLifePrefs = 1 + PlayerPrefs.GetInt("StatsMaxLives", 1);
        playerLife = playerLifePrefs;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            playerSFX.PlayOneShot(attackAudio);
        }

        if (health <= 0)
        {
            playerLife--;

            if (playerLife == 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.position = respawnPoint;
                health = maxHealth;
            }
        }
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void ChangeHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    private void OnDestroy()
    {
        this.gameObject.SetActive(false);
    }
}
