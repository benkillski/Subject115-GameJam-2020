using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballAI : MonoBehaviour
{
    public bool moveHorizontally;
    public bool moveVertically;

    public int eyeballSpeed = 10;

    private Vector2 eyeballVelocity;

    // Start is called before the first frame update
    void Start()
    {
        if(moveHorizontally)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * eyeballSpeed; 
            eyeballVelocity = GetComponent<Rigidbody2D>().velocity;
        }
        else if(moveVertically)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * eyeballSpeed;
            eyeballVelocity = GetComponent<Rigidbody2D>().velocity;
        }
    }

    void Flip()
    {
        if(moveHorizontally)
        {
            transform.Rotate(180f, 0f, 0f);
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(eyeballVelocity.x * -1, 0);
            eyeballVelocity = GetComponent<Rigidbody2D>().velocity;
        }
        else if(moveVertically)
        {
            transform.Rotate(0f, 0f, 180f);
          
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, eyeballVelocity.y * -1);
            eyeballVelocity = GetComponent<Rigidbody2D>().velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision made");

        if(col.gameObject != null && col.gameObject.tag != "Player") 
            Flip();

        else if(col.gameObject.tag == "Player")
            GetComponent<Rigidbody2D>().velocity = eyeballVelocity;
    }
}
