using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayToggle : MonoBehaviour
{
    static bool Paused = false;
    static bool Win = false;
    static bool Lost = false;
    public GameObject PausedCanvas;
    public GameObject WinCanvas;
    public GameObject LostCanvas;

    void Start()
    {
        Win = false;
        Lost = false;
    }

    ///<summary>alternates the paused state</summary>
    public void TogglePausing()
    {
        Paused = !Paused;

        if (Paused)
        {
            //shows pause screen
            PausedCanvas.SetActive(true);
        }
        else
        {
            //hides pause screen
            PausedCanvas.SetActive(false);
        }
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
