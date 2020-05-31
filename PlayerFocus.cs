using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFocus : MonoBehaviour
{
    public FocusBar focusBar;

    public int playerFocus;
    public bool canPlayerFocus;

    private const float FOCUS_RECHARGE_DELAY = 0.5f;
    private float lastFocusTime;


    // Start is called before the first frame update
    void Start()
    {
        focusBar.SetMaxFocus(100);
        SetPlayerFocus(0);
        canPlayerFocus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlayerFocus)
            StartCoroutine(RechargeFocus());
    }

    public void DrainPlayerFocus(int amount)
    {
            playerFocus -= amount;
            focusBar.SetFocus(playerFocus);
            lastFocusTime = Time.time;
    }

    public void GainPlayerFocus(int amount)
    {
            playerFocus += amount;
            focusBar.SetFocus(playerFocus);
    }

    IEnumerator RechargeFocus()
    {
        if(Time.time - lastFocusTime >= FOCUS_RECHARGE_DELAY && playerFocus < 100)
        {
            GainPlayerFocus(5);
            lastFocusTime = Time.time;
            yield return new WaitForSeconds(1);
        }
    }

    public int GetPlayerFocus()
    {
        return playerFocus;
    }

    public void SetPlayerFocus(int playerFocus)
    {
        this.playerFocus = playerFocus;
        focusBar.SetFocus(playerFocus);
    }

    public bool GetCanPlayerFocus()
    {
        return canPlayerFocus;
    }

    public void SetCanPlayerFocus(bool canPlayerFocus)
    {
        this.canPlayerFocus = canPlayerFocus;
    }
}
