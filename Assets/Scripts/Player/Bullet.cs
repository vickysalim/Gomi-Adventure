using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;

    public float bulletTimer;
    public float maxBulletTimer;

    public GameObject player;
    private CharacterController2D cc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharacterController2D>();

        if (!cc.m_FacingRight)
        {
            rb.velocity = -(transform.right * speed);
        }
        else
        {
            rb.velocity = transform.right * speed;
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
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("bullet hit enemy");
            Destroy(this.gameObject);
        }
    }
}
