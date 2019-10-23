using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesRemaining : MonoBehaviour
{
    private TextMeshProUGUI LivesRemainingText;
    private LevelManager LevelManagerScript;
    public GameObject TileManagerGO;

    /// <summary>
    /// Gets the tile manager script from the tile manager object
    /// gets the text on the object this script is attached to
    /// </summary>
    void Start()
    {
        LevelManagerScript = TileManagerGO.GetComponent<LevelManager>();
        LivesRemainingText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the text to show many lives are left
    /// </summary>
    void Update()
    {
        int numberOfLives = LevelManagerScript.health;
        LivesRemainingText.SetText("Lives \nremaining: " + numberOfLives);
    }
}
