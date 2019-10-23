using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayToggle : MonoBehaviour
{
    bool Paused = false;
    bool Options = false;
    bool Win = false;
    bool Lost = false;
    public GameObject PausedCanvas;
    public GameObject OptionsCanvas;
    public GameObject WinCanvas;
    public GameObject LostCanvas;
    private int PrevSpeed = 1;

    void Start()
    {
        Win = false;
        Lost = false;
    }

    ///<summary>alternates the paused state</summary>
    public void TogglePausing()
    {
        Paused = !Paused;

        //shows/hides pause screen
        PausedCanvas.SetActive(Paused);

        if (Paused)
        {
            PrevSpeed = SpeedFunctionality.GameSpeed;
            SpeedFunctionality.GameSpeed = 0;
        }
        else
        {
            SpeedFunctionality.GameSpeed = PrevSpeed;
        }
    }

    ///<summary>alternates the option state</summary>
    public void ToggleOptions()
    {
        Options = !Options;

        //shows/hides options screen
        OptionsCanvas.SetActive(Options);
    }


    ///<summary>turns on win state</summary>
    public void WonGame()
    {
        Win = true;

        //shows pause screen
        WinCanvas.SetActive(true);
    }

    ///<summary>turns on lost state</summary>
    public void LostGame()
    {
        Lost = true;

        //shows pause screen
        LostCanvas.SetActive(true);
    }
}
