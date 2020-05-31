using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject firePoint;

    public bool isShooting = false;
    public int shootToIdleDelay;

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;

    private float moveX;
    public bool facingRight;

    public bool isGrounded;
    public bool isCrouching;
    public bool isMoving;
    public bool isJumping;

    private const float DASH_DELAY_TIME = 0.5f;
    int dashButtonPresses = 0;
    float dashButtonPressTime;



    

    // Update is called once per frame
    void Update()
    {
        ExitGame();
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //CONTROLS

        //Horizontal Movement
        moveX = Input.GetAxisRaw("Horizontal");

        if(Input.GetAxisRaw("Horizontal") != 0 && isCrouching == false)
        {
            isMoving = true;

            if(Input.GetButtonDown("TimeDash") && dashButtonPresses < 2 && GetComponent<TimeDash>().GetTimeDashStatus() == true)
            {
                dashButtonPressTime = Time.time;
                dashButtonPresses++;
                GetComponent<TimeDash>().TimeDashMove(facingRight);
            }
            else if(dashButtonPresses > 2 || Time.time - dashButtonPressTime > DASH_DELAY_TIME)
            {
                dashButtonPresses = 0;
            }
        }
        else if(Input.GetAxisRaw("Horizontal") != 0 && isCrouching == true)
        {
           isMoving = true;
           Crouch(); 
        }
        else
        {
            isMoving = false;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (!isCrouching)
            {
                Jump();
            } else if(isCrouching)
            {
                Crouch();
            }
        }

        //Crouching
        if(Input.GetButtonDown("Crouch") && isGrounded)
        {
            Crouch();
        } 

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            shootToIdleDelay = 500;
        }
        else
        {
            isShooting = false;
            --shootToIdleDelay;
        }

        //ANIMATIONS
        if (moveX != 0 && isGrounded) //Running
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        } 
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }

        if(isGrounded == false)
        {
            GetComponent<Animator>().SetBool("IsJumping", true); //Jumping
        } 
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false); //Jumping
        }
        
        GetComponent<Animator>().SetBool("IsCrouching", isCrouching); //Crouching

        GetComponent<Animator>().SetBool("IsShooting", isShooting); //Shooting
        GetComponent<Animator>().SetInteger("ShootToIdleDelay", shootToIdleDelay); //Shooting back to Idle


        //PLAYER DIRECTION
        if (moveX < 0.0f && !facingRight)
        {
            Flip();
        }
        else if (moveX > 0.0f && facingRight)
        {
            Flip();
        }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isJumping = true;
    }

    void Crouch()
    {
        if (!isCrouching)
        {
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, -0.71f); 
            GetComponent<CapsuleCollider2D>().size = new Vector2(GetComponent<CapsuleCollider2D>().size.x, 1.58244f);
            firePoint.transform.localPosition = new Vector2(1.11f, -0.63f);

            isCrouching = true;
        } 
        else if(isCrouching)
        {
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, -0.3351988f); 
            GetComponent<CapsuleCollider2D>().size = new Vector2(GetComponent<CapsuleCollider2D>().size.x, 2.387625f);
            firePoint.transform.localPosition = new Vector2(1.11f, 0.2f);

            isCrouching = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetComponent<CapsuleCollider2D>().bounds.center, Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);
        Debug.DrawRay(GetComponent<CapsuleCollider2D>().bounds.center, Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f), Color.green);

        RaycastHit2D hitBackside = Physics2D.Raycast(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x - .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);
        Debug.DrawRay(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x - .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f), Color.red);

        RaycastHit2D hitFrontside = Physics2D.Raycast(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x + .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down, GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f);
        Debug.DrawRay(new Vector2(GetComponent<CapsuleCollider2D>().bounds.center.x + .25f, GetComponent<CapsuleCollider2D>().bounds.center.y), Vector2.down * (GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f), Color.blue);

        if(hit.collider != null || hitBackside.collider != null || hitFrontside.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public float GetMoveX()
    {
        return moveX;
    }

    void ExitGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
