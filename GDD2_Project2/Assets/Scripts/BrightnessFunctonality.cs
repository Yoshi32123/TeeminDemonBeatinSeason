using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessFunctonality : MonoBehaviour
{
    public float GammaCorrection;


    void Update()
    {
        
        RenderSettings.ambientLight = new Color(GammaCorrection, GammaCorrection, GammaCorrection, 1.0f);
    }

    public void OnValueChanged(float newValue)
    {
        GammaCorrection = newValue;
    }
}