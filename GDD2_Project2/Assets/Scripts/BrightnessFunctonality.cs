using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessFunctonality : MonoBehaviour
{
    float brightness = 0;
    public Renderer rend;
    public void Update()
    {
        Debug.Log(rend.sharedMaterial.GetFloat("_Brightness"));
        rend.sharedMaterial.SetFloat("_Brightness", brightness);
    }

    public void OnValueChanged(float newValue)
    {
        //range of -0.5f to 0.7f
        brightness = (newValue*1.2f)-0.5f;
        rend.sharedMaterial.SetFloat("_Brightness", brightness);
    }
}