using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    public int playerHealth = 100;
    public int maxHealth;

    public int harmfulObjectDamage = 5;
    public int enemyDamage = 10;

    public bool isTakingDamage = false;
    public bool isInvulnerable = false;

    void Start()
    {
        maxHealth = 100;
        healthBar.SetMaxHealth(maxHealth);
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnCollisionStay2D(Collision2D col) //If player collides with a harmful object, spikes, acid, ect. damage the player.
    { 
        if(col.gameObject.tag == "Harmful" && !isInvulnerable)
        {
            DamagePlayer(harmfulObjectDamage);
        }
        else if(col.gameObject.tag == "Enemy" && !isInvulnerable)
        {
            DamagePlayer(enemyDamage);
        }
        else
        {
            isTakingDamage = false;
        }  
    }

    void OnEventTrigger2D(Collider2D col)
    {
        if(col.gameObject.tag == "Harmful" && !isInvulnerable)
        {
            DamagePlayer(harmfulObjectDamage);
        }
        else 
        {
            isTakingDamage = false;
        }
    }

    public void DamagePlayer(int damage)
    {
        isTakingDamage = true;
     
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        
         if(playerHealth <= 0)
        {
            Die();
        }

        isInvulnerable = true;
        StartCoroutine(SpriteFlash());
    }

    IEnumerator SpriteFlash()
    {
        for (int n = 0; n < 4; n++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }
        isInvulnerable = false;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f);
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScreen"); 
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth(int healthAmount)
    {
        playerHealth = healthAmount;
        healthBar.SetHealth(healthAmount);
    }
    
    public void SetMaxHealth(int amountGained)
    {
        maxHealth += amountGained;
        healthBar.SetMaxHealth(maxHealth);
    }

}
