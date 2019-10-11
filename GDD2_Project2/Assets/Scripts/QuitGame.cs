using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    /*
     * Kills the game application
     * Only works in a compiled application (windowed)
     */
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
