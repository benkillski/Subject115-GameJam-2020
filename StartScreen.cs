using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public string firstLevel;

    public void Update()
    {
        if(!Input.GetMouseButtonDown(0))
        {
            return;
        }

        SceneManager.LoadScene (firstLevel);
    }
}
