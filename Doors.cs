using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject keyObject;
    private Key requiredKey;

    public TextMeshProUGUI requiredItemUI;

    void Start()
    {
        requiredKey = keyObject.GetComponent<Key>();
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            foreach(Item key in PlayerInventory.playerItems)
            {
                if(key.GetItemName().Equals(requiredKey.GetItemName()))
                {
                    Destroy(gameObject);
                    Destroy(requiredKey);
                    return;
                }   
            }
            Debug.Log("Player needs the " + requiredKey.GetItemType());
            StartCoroutine(DisplayRequiredKeyUI());
        }
    }

    IEnumerator DisplayRequiredKeyUI()
    {
        requiredItemUI.text = "You need the " + requiredKey.GetItemType();
        yield return new WaitForSeconds(5);
        requiredItemUI.text = "";
    }
}
