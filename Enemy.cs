using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public bool isDead = false;

    public GameObject player;

    public GameObject healthDrop;
    public GameObject missleDrop;
    public string dropType;

    public float dropPercentage;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemyDrops();
        Destroy(gameObject);
    }

    void EnemyDrops() 
    {
        ChooseDropType();

        if(player.GetComponent<PlayerInventory>().GetMissleAbilityStatus() == true )

        switch(dropType)
        {
            case "health":

            if(player.GetComponent<PlayerHealth>().GetHealth() != player.GetComponent<PlayerHealth>().GetMaxHealth())
            {
                if(player.GetComponent<PlayerHealth>().GetHealth() > player.GetComponent<PlayerHealth>().GetMaxHealth() / 2)
                {
                    dropPercentage = 40.0f;
                }
                else
                {
                    dropPercentage = 60.0f;
                }

                if(((int) (Random.Range(0f, 1f) * 100)) < dropPercentage)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.identity);
                }
            }
            break;

            case "missle":

            if(player.GetComponent<PlayerInventory>().GetCurrentMissleCount() != player.GetComponent<PlayerInventory>().GetMissleCapacity())
            {
                if(player.GetComponent<PlayerInventory>().GetCurrentMissleCount() > player.GetComponent<PlayerInventory>().GetMissleCapacity() / 1.5)
                {
                    dropPercentage = 40.0f;
                }
                else 
                {
                    dropPercentage = 60.0f;
                }

                if(((int) (Random.Range(0f, 1f) * 100)) < dropPercentage)
                {
                    Instantiate(missleDrop, transform.position, Quaternion.identity);
                }
            }
            break;
        }
    }

    void ChooseDropType()
    {
        int dropDescionPercentage = (int) (Random.Range(0f, 1f) * 100);

        if(dropDescionPercentage > 50.0f)
        {
            if(player.GetComponent<PlayerInventory>().GetMissleAbilityStatus() == true)
                dropType = "missle";

            else 
                dropType = "health";
        }
        else
        {
            dropType = "health";
        }
    }

    public bool GetDeathStatus()
    {
        return isDead;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy Drop")
        {
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), col.gameObject.GetComponent<CapsuleCollider2D>());
        }
    }
}
