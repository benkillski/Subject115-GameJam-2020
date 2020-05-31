using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

        if(player != null)
        {
            player.DamagePlayer(damage);
        }
        else if(hitInfo.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), hitInfo.gameObject.GetComponent<CapsuleCollider2D>());
        }

        if(hitInfo.tag != "Bullet" && hitInfo.tag != "Enemy")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
