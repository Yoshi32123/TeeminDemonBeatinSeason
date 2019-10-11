using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{


    /*
     * switches to the scene whose name matches the given game.
     * string nextSceneName - Scene name to switch to
     */
    public void NextScene(string nextSceneName)
    {
        PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nextSceneName);
    }
}
