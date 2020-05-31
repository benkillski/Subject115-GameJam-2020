using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDash : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;
    PlayerFocus pf;
    PlayerHealth ph;
    

    public int timeDashPower = 1000;

    bool canTimeDash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
        pf = GetComponent<PlayerFocus>();
        ph = GetComponent<PlayerHealth>();

        canTimeDash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canTimeDash == false)
            TimeDashCheck();
    }

    void TimeDashCheck()
    {
        foreach(Item item in PlayerInventory.playerItems)
        {
            if(item.GetItemName() == "TimeDashUpgrade")
            {
                ph.SetHealth(ph.GetMaxHealth());

                pf.SetCanPlayerFocus(true); 
                pf.SetPlayerFocus(100);
                canTimeDash = true;
                break;
            }
        }
    }

    public bool GetTimeDashStatus()
    {
        return canTimeDash;
    }

    public void TimeDashMove(bool facingRight)
    {
        if(pf.GetPlayerFocus() >= 10)
        {
            pf.DrainPlayerFocus(10);

            if(facingRight)
                rb.AddForce(Vector2.left * timeDashPower);

            else if(!facingRight)
                rb.AddForce(Vector2.right * timeDashPower);
        }
    }
}
