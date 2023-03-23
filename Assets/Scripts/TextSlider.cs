using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private Slider slider;

    public void SetNumberText(float value)
    {
        numberText.text = value.ToString();
    }
    void start(){
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
    }
}
