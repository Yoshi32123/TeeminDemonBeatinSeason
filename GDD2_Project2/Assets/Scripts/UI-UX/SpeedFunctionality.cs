using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedFunctionality : MonoBehaviour
{
    public static int GameSpeed = 1;
    public GameObject SpeedButtonText;

    //sets speed to 1 at start
    void Start()
    {
        GameSpeed = 1;
        SpeedButtonText.GetComponent<Text>().text = "Speed: x1";
    }


    /// <summary>
    /// Toggles the spedup variable and set the text to match the new speed
    /// </summary>
    public void ToggleSpeed()
    {
        GameSpeed++;
        if (GameSpeed > 3)
            GameSpeed = 1;

        SpeedButtonText.GetComponent<Text>().text = "Speed: x" + GameSpeed.ToString();
    }
}
