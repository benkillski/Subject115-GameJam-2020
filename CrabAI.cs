using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : MonoBehaviour
{
    public int crabSpeed = 5;
    public int xMoveDirection;
    public float raycastDistance = 1.15f;

    // Update is called once per frame
    void Update()
    {
        CrabMove();
    }

    void CrabMove()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * crabSpeed;
    }

    void Flip()
    {
        if(xMoveDirection > 0)
        {
            xMoveDirection = -1;
            transform.Rotate(0, 180, 0);
        }
        else
        {
            xMoveDirection = 1;
            transform.Rotate(0, 180, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Wall" || col.gameObject.tag == "Enemy")
        {
            Flip();
        }
    }

}
