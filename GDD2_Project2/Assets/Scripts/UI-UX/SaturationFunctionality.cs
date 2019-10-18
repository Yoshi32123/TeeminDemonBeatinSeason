using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaturationFunctionality : MonoBehaviour
{
    //render is used to change shader value for all objects using it
    float saturation = 1;
    public Renderer rend;

    //sets slider to shader's value
    void Start()
    {
        float startValue = (rend.sharedMaterial.GetFloat("_Saturation") / 3f);
        Slider slider = gameObject.GetComponent<Slider>();
        slider.normalizedValue = startValue;
        saturation = startValue;
    }

    //when slider is moved, send new value to shader
    public void OnValueChanged(float newValue)
    {
        //range of 0f to 3f
        saturation = (newValue * 3f);
        rend.sharedMaterial.SetFloat("_Saturation", saturation);
    }
}
