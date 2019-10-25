using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemonNumber : MonoBehaviour
{
    private TextMeshProUGUI DemonComingText;
    private TowerBuilder TowerBuilderScript;
    private TileManager TileManagerScript;
    public GameObject TileManagerGO;

    /// <summary>
    /// Gets the tile manager script from the tile manager object
    /// gets the text on the object this script is attached to
    /// </summary>
    void Start()
    {
        TowerBuilderScript = TileManagerGO.GetComponent<TowerBuilder>();
        TileManagerScript = TileManagerGO.GetComponent<TileManager>();
        DemonComingText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the text to show many demons are coming
    /// </summary>
    void Update()
    {
        if (!TileManagerScript.GetEndHasBeenReached())
        {
            int numberOfDemons = TowerBuilderScript.numberOfEnemies;
            DemonComingText.SetText("Demons \nincoming: " + numberOfDemons);
        }
        else
        {
            DemonComingText.enabled = false;
        }
    }
}
