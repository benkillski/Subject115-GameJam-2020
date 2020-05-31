using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpiderBossAI : MonoBehaviour
{
    public GameObject player;

    public GameObject bossEntreDoor;
    public GameObject upgradeDoor;

    public Transform firePoint1;

    public GameObject bulletPrefab;

    public int jumpPower = 5000;
    public int robotSpiderSpeed = 8;
    public int xMoveDirection = -1;

    public bool isFighting;

    public bool inSequence = false;



    // Start is called before the first frame update
    void Start()
    {
        xMoveDirection = -1;
        transform.Rotate(0f, 180f, 0f);
        isFighting = false;
    }

    // Update is called once per frame
    void Update()
    {
       HasBossFightStarted();

       if(isFighting == true)
       {
           bossEntreDoor.SetActive(true);

            if(inSequence != true)
                StartCoroutine(FightSequence());
       }
    }

    void HasBossFightStarted()
    {
        if(Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) <= 18 && Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) <= 5)
        {
            isFighting = true;
        }
    }

    IEnumerator FightSequence()
    {
        inSequence = true;

       for(int i = 0; i < 10; i++)
        {
            Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);

        for(int i = 0; i < 3; i++)
        {
            Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            yield return new WaitForSeconds(.75f);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * robotSpiderSpeed;
            yield return new WaitForSeconds(1f);
        }

        ChangeDirection();

         for(int i = 0; i < 3; i++)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * robotSpiderSpeed;
            Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            yield return new WaitForSeconds(1.5f);
        }

        ChangeDirection();
        
        inSequence = false;
    }

    void ChangeDirection()
    {
        if(xMoveDirection == 1) 
        {
            xMoveDirection = -1;
            transform.Rotate(0, 180, 0);
        }

        else if(xMoveDirection == -1)
        {
            xMoveDirection = 1;
            transform.Rotate(0, 180, 0);
        }
    }

}
