using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static List<Item> playerItems = new List<Item>();
    private int currentLength = 0;
    private int lastLength = 0;
    
    public MissleBar missleBar;
    public int missleCapacity = 0;
    public int currentMissleCount = 0;
    public bool canUseMissles = false;

    public TextMeshProUGUI playerPickUpUI;



    void Start()
    {
        missleCapacity = 0;
        currentMissleCount = 0;
        canUseMissles = false;
        missleBar.SetMaxMissleAmount(missleCapacity);
        missleBar.SetMissleAmount(currentMissleCount);
    }

    // Update is called once per frame
    void Update()
    {
       currentLength = playerItems.Count; 
       
       if(currentLength > lastLength)
       {
           StartCoroutine(DisplayPlayerPickUpUI());
           lastLength = currentLength;
       }
       
        if(canUseMissles == true)
        {
            missleBar.gameObject.SetActive(true);
        }
    }

    IEnumerator DisplayPlayerPickUpUI()
    {
        playerPickUpUI.text = "You have obtained a " + playerItems[playerItems.Count - 1].GetItemType();
        yield return new WaitForSeconds(5);
        playerPickUpUI.text = "";
    }

    public int GetMissleCapacity()
    {
        return missleCapacity;
    }

    public int GetCurrentMissleCount()
    {
        return currentMissleCount;
    }

    public void IncreaseMissleCapacity(int amountGained)
    {
        missleCapacity += amountGained;
        missleBar.SetMaxMissleAmount(missleCapacity);
    }

    public void SetCurrentMissleCount(int missleAmount)
    {
        currentMissleCount = missleAmount;
        missleBar.SetMissleAmount(currentMissleCount);
    }

    public bool GetMissleAbilityStatus()
    {
        return canUseMissles;
    }

    public void SetMissleAbilityStatus(bool status)
    {
        canUseMissles = status;
    }
}
