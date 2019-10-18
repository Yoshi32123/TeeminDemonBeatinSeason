using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScene : MonoBehaviour
{
    /**
     * <summary>Resets scene back to starting state</summary>
     */
    public void ResettingScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
