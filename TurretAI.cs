using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public GameObject player;

    public GameObject bulletPrefab; 
    public Transform firePoint;

    private bool isShooting;

    public float playerRangeX = 30;

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting == false && Mathf.Abs(player.transform.position.x - transform.position.x) < playerRangeX)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(1.5f);
        isShooting = false;
    }
}
