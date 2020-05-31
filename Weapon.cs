using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject misslePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            ShootMissle();
        }

        
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootMissle()
    {
        if(GetComponent<PlayerInventory>().GetCurrentMissleCount() > 0)
        {
            Instantiate(misslePrefab, firePoint.position, firePoint.rotation);
            GetComponent<PlayerInventory>().SetCurrentMissleCount(GetComponent<PlayerInventory>().GetCurrentMissleCount() - 1);
        }
    }
}
