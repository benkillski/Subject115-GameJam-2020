using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissleBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMissleAmount(int maxMissleAmount)
    {
        slider.maxValue = maxMissleAmount;
    }

    public void SetMissleAmount(int missleAmount)
    {
        slider.value = missleAmount;
    }
}
