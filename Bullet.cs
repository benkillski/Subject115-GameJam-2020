using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        else if(hitInfo.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), hitInfo.gameObject.GetComponent<CircleCollider2D>());
        }

        if(hitInfo.tag != "Bullet" && hitInfo.tag != "Enemy Drop")
        Instantiate(impactEffect, transform.position, transform.rotation);

        if(hitInfo.tag != "Enemy Drop")
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy Drop")
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), col.gameObject.GetComponent<CapsuleCollider2D>());
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
