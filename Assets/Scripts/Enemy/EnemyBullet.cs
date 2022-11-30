using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    public float bulletTimer;
    public float maxBulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // enemy facing left/right not set yet
        rb.velocity = -(transform.right * speed);
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

            Debug.Log("enemy bullet hit player");
            
            // behavior when touching player not yet
        }
    }
}
