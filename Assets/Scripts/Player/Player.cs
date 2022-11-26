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
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = this.transform.position;
        health = Mathf.Clamp(0, maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        if(health <= 0)
        {
            playerLife--;

            if(playerLife == 0)
            {
                Destroy(this.gameObject);
            } else
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

    private void OnDestroy()
    {
        this.gameObject.SetActive(false);
    }
}
