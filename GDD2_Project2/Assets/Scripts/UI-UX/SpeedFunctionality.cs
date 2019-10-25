using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedFunctionality : MonoBehaviour
{
    public static int CurrentGameSpeed = 1;
    public static int StoredGameSpeed = 1; //so leaving level after pausing and coming back will keep game speed the same
    public GameObject SpeedButtonText;

    //sets speed to 1 at start
    void Start()
    {
        if(CurrentGameSpeed == 0)
        {
            CurrentGameSpeed = StoredGameSpeed;
        }

        SpeedButtonText.GetComponent<Text>().text = "Speed: x" + CurrentGameSpeed.ToString();
    }


    /// <summary>
    /// Toggles the spedup variable and set the text to match the new speed
    /// </summary>
    public void ToggleSpeed()
    {
        CurrentGameSpeed++;
        if (CurrentGameSpeed > 3)
            CurrentGameSpeed = 1;
        StoredGameSpeed = CurrentGameSpeed;

        SpeedButtonText.GetComponent<Text>().text = "Speed: x" + CurrentGameSpeed.ToString();
    }
}
