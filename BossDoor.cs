using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public GameObject boss;

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
            Destroy(gameObject);
    }
}
