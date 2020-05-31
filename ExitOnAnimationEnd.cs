using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnAnimationEnd : MonoBehaviour
{
    void KillAnimation()
    {
        Destroy(gameObject);
    }
}
