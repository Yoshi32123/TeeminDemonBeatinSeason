using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingRoadText : MonoBehaviour
{
    private TextMeshProUGUI RemainerText;
    private TileManager TileManagerScript;
    public GameObject TileManagerGO;

    /// <summary>
    /// Gets the tile manager script from the tile manager object
    /// gets the text on the object this script is attached to
    /// </summary>
    void Start()
    {
        TileManagerScript = TileManagerGO.GetComponent<TileManager>();
        RemainerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the text to show many roads are left to be placed
    /// </summary>
    void Update()
    {
        //Have to do +1 because the user sets the starting tile road which counts towards the road count. 
        //Without the +1, using all roads will give "-1" due to that starting road being set by user instead of TileManager starting next to starting tile.
        RemainerText.SetText("Remaining Roads: " + (TileManagerScript.maxPathTiles - TileManagerScript.finalPath.Count + 1));
    }
}
