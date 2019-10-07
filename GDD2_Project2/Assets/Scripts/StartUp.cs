using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    #region Variables
    // Instantiating Variables
    private float[] startUpX;
    private float[] startUpY;
    private GameObject[,] starterTiles;
    public float tileDifferential;

    public GameObject templateSquare;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TileStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets up base variables for tiling
    /// </summary>
    void TileStartUp()
    {
        // setting up matrix values
        startUpX = new float[15];
        startUpY = new float[7];
        starterTiles = new GameObject[15, 7];
        if (tileDifferential == 0)
            tileDifferential = 1.05f;

        // inputting base values for matrix
        for (int i = 0; i < startUpX.Length - 1; i++)
        {

        }
    }
}
