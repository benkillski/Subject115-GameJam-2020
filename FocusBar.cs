using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxFocus(int maxFocus)
    {
        slider.maxValue = maxFocus;
    }

    public void SetFocus(int focus)
    {
        slider.value = focus;
    }
}
