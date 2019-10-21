using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemainingRoadText : MonoBehaviour
{
    private TextMeshProUGUI RemainerText;
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
        RemainerText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the text to show many roads are left to be placed
    /// </summary>
    void Update()
    {
        int remainingTiles = (TowerBuilderScript.maxPathTiles - TileManagerScript.finalPath.Count);

        //ignore starting tile so it doesn't count towards out tile count
        if(remainingTiles != TowerBuilderScript.maxPathTiles)
        {
            remainingTiles++;
        }
        //ignore end tile so it doesn't count and make tile count -1 when using all tiles 
        if(TileManagerScript.GetEndHasBeenReached())
        {
            remainingTiles++;
        }
        
        RemainerText.SetText("Remaining Roads: " + remainingTiles);
    }
}
