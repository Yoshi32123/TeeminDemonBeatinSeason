using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    #region Variables
    // Instantiating Variables
    public int xTiles;
    public int yTiles;
    private float[] startUpX;
    private float[] startUpY;
    private GameObject[,] starterTiles;

    public float TopLeftX;
    public float TopLeftY;
    public float tileDifferential;

    public GameObject templateSquare;

    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TileStartUp();
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickCheck();
    }

    /// <summary>
    /// Sets up base variables for tiling
    /// </summary>
    public void TileStartUp()
    {
        // setting up matrix values
        startUpX = new float[xTiles];
        startUpY = new float[yTiles];
        starterTiles = new GameObject[xTiles, yTiles];
        if (tileDifferential == 0.0f)
            tileDifferential = 1.05f;

        // inputting base values for matrix
        for (int i = 0; i < startUpX.Length; i++)
        {
            startUpX[i] = TopLeftX + (tileDifferential * i);
        }
        for (int i = 0; i < startUpY.Length; i++)
        {
            startUpY[i] = TopLeftY - (tileDifferential * i);
        }

        // instantiating objects and adding to 2D array
        for (int i = 0; i < startUpX.Length; i++)
        {
            for (int j = 0; j < startUpY.Length; j++)
            {
                starterTiles[i,j] = Instantiate(templateSquare, new Vector2(startUpX[i], startUpY[j]), Quaternion.identity);
            }
        }
    }

    /// <summary>
    /// Changes the color of the object that was clicked on
    /// </summary>
    /// <param name="clickedObject"> The object that was clicked on </param>
    public void ChangeColor(GameObject clickedObject)
    {
        // gets sprite renderer and changes the sprite
        clickedObject.GetComponent<SpriteRenderer>().sprite = greenSprite;
    }

    /// <summary>
    /// Detects mouse click and checks for collision with any boxes
    /// </summary>
    public void MouseClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                ChangeColor(hit.collider.gameObject);
            }
        }
    }
}
