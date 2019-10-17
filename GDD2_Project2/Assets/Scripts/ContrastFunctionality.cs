using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ContrastFunctionality : MonoBehaviour
{
    //render is used to change shader value for all objects using it
    float contrast = 1;
    public Renderer rend;

    //sets slider to shader's value
    void Start()
    {
        float startValue = (rend.sharedMaterial.GetFloat("_Contrast") - 0.3f) / 2.7f;
        Slider slider = gameObject.GetComponent<Slider>();
        slider.normalizedValue = startValue;
        contrast = startValue;
    }

    //when slider is moved, send new value to shader
    public void OnValueChanged(float newValue)
    {
        //range of 0.3f to 3.0f
        contrast = (newValue * 2.7f) + 0.3f;
        rend.sharedMaterial.SetFloat("_Contrast", contrast);
    }
}
