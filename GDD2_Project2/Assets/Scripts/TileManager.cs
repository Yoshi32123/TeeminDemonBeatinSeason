using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region Variables
    // Instantiating Variables
    public int xTiles;
    public int yTiles;
    private float[] startUpX;
    private float[] startUpY;
    private GameObject[,] starterTiles;

    private List<GameObject> finalPath;

    public float TopLeftX;
    public float TopLeftY;
    public float tileDifferential;

    public GameObject templateSquare;

    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;

    private GameObject start;
    private GameObject end;
    private GameObject lastTileClicked;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        TileStartUp();

        // setting up the start and end tiles
        start = Instantiate(templateSquare, new Vector2(starterTiles[0,1].transform.position.x - tileDifferential, starterTiles[0, 1].transform.position.y), Quaternion.identity);
        ChangeColor(start, greenSprite);
        //finalPath.Add(start);
        end = Instantiate(templateSquare, new Vector2(starterTiles[xTiles-1, yTiles-2].transform.position.x + tileDifferential, starterTiles[xTiles - 1, yTiles - 2].transform.position.y), Quaternion.identity);
        ChangeColor(end, greenSprite);

        // setting first choice available
        ChangeColor(starterTiles[0, 1], greenSprite);
        lastTileClicked = starterTiles[0, 1];
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickCheck();
        NextPathChoices();
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
    public void ChangeColor(GameObject clickedObject, Sprite sprite)
    {
        // gets sprite renderer and changes the sprite
        clickedObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    /// <summary>
    /// Detects mouse click and checks for collision with any boxes
    /// </summary>
    public void MouseClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (ValidPath(hit.collider.gameObject))
                {
                    lastTileClicked = hit.collider.gameObject;
                    ChangeColor(hit.collider.gameObject, greenSprite);
                }
            }
        }
    }

    /// <summary>
    /// Determines if the clicked cell is valid
    /// </summary>
    /// <param name="clickedObject">The object that was clicked on</param>
    /// <returns></returns>
    public bool ValidPath(GameObject clickedObject)
    {
        if (clickedObject.GetComponent<SpriteRenderer>().sprite == blueSprite)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Will set the cells available for the next path choice
    /// </summary>
    public void NextPathChoices()
    {
        int xIndex = -1;
        int yIndex = -1;

        for (int i = 0; i < startUpX.Length; i++)
        {
            for (int j = 0; j < startUpY.Length; j++)
            {
                if (lastTileClicked == starterTiles[i, j])
                {
                    xIndex = i;
                    yIndex = j;
                }
            }
        }

        for (int i = 0; i < startUpX.Length; i++)
        {
            for (int j = 0; j < startUpY.Length; j++)
            {
                if (starterTiles[i, j].GetComponent<SpriteRenderer>().sprite == greenSprite || starterTiles[i, j] == lastTileClicked)
                {
                    // do nothing
                }
                else if (i == xIndex + 1 && j == yIndex || i == xIndex - 1 && j == yIndex || i == xIndex && j == yIndex + 1 || i == xIndex && j == yIndex - 1)
                {
                    // checks if cell is tower
                    if (/*cell is tower*/false)
                    {

                    }
                    else
                    {
                        starterTiles[i, j].GetComponent<SpriteRenderer>().sprite = blueSprite;
                    }
                }
                else
                {
                    starterTiles[i, j].GetComponent<SpriteRenderer>().sprite = redSprite;
                }
            }
        }
    }
}
