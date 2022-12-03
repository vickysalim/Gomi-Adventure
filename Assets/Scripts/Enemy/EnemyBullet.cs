using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    public float bulletTimer;
    public float maxBulletTimer;
    public int damage = 5;

    public GameObject playerObject;
    public Player player;

    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerObject = GameObject.FindGameObjectWithTag("Player");

        if(playerObject != null)
            player = playerObject.GetComponent<Player>();

        // enemy facing left/right not set yet
        if(!isFacingRight)
        {
            rb.velocity = -(transform.right * speed);
        } else
        {
            rb.velocity = (transform.right * speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer > maxBulletTimer)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            player.ChangeHealth(-damage);
        }
    }
}
