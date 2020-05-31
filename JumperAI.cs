using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperAI : MonoBehaviour
{
    public GameObject player;

    public int jumperJumpPower = 1750;
    public int jumperSpeed = 10;
    public int xMoveDirection;

    public bool isGrounded = true;

    public float distanceFromSprite;

    // Update is called once per frame
    void Update()
    {
        JumperMove();
        JumperRaycast();
    }

    void JumperMove()
    {
        if((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 20f) && (Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) < 15)) {
            if(isGrounded == true) 
            {
                ChangeDirection();
                Jump();
            }
        }  
    }

    void Jump()
    {   
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * jumperSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumperJumpPower);
        isGrounded = false;
        GetComponent<Animator>().SetBool("IsGrounded", false);
    }

    void ChangeDirection()
    {
        if(player.transform.position.x < gameObject.transform.position.x)
        {
            xMoveDirection = -1;
        }
        else if(player.transform.position.x > gameObject.transform.position.x)
        {
            xMoveDirection = 1;
        }
        else{
            xMoveDirection = 0;
        }
    }

    void JumperRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetComponent<CapsuleCollider2D>().bounds.center, Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);

        RaycastHit2D hitBackside = Physics2D.Raycast(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x - .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);

        RaycastHit2D hitFrontside = Physics2D.Raycast(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x + .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);
      

        if((hit.collider != null && hitBackside.collider != null && hitFrontside.collider != null) && (hit.collider.tag != "Bullet" && hitBackside.collider.tag != "Bullet" && hitFrontside.collider.tag != "Bullet"))
        {
            isGrounded = true;
            GetComponent<Animator>().SetBool("IsGrounded", true);
        }
    }
}
