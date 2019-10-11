using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PreviousScene : MonoBehaviour
{
    //
    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("previousScene"));
    }
}
