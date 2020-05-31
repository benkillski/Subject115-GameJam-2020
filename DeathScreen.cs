using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public string respawnLevel;

    // Update is called once per frame
    public void Update()
    {
      if(!Input.GetMouseButtonDown(0))  
      {
        return;
      }
      SceneManager.LoadScene(respawnLevel);
    }
}
