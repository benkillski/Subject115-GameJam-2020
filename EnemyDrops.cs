using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public string dropType;

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), col.gameObject.GetComponent<CircleCollider2D>());
        }

        if(col.gameObject.tag == "Player" && dropType.Equals("health"))
        {
            col.gameObject.GetComponent<PlayerHealth>().SetHealth(col.gameObject.GetComponent<PlayerHealth>().GetHealth() + 5);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Player" && dropType.Equals("missle"))
        {
            col.gameObject.GetComponent<PlayerInventory>().SetCurrentMissleCount(col.gameObject.GetComponent<PlayerInventory>().GetCurrentMissleCount() + 1);
            Destroy(gameObject);
        }
    }
}
