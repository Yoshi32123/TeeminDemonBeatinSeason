using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region Variables
    // Instantiating Variables
    private int xTiles;
    private int yTiles;
    private float[] startUpX;
    private float[] startUpY;
    private GameObject[,] starterTiles;

    public List<Vector2> finalPath = new List<Vector2>();
    public int maxPathTiles;

    private float TopLeftX;
    private float TopLeftY;
    private float tileDifferential = 1.05f;

    private bool endHasBeenReached = false;
    public bool GetEndHasBeenReached() { return endHasBeenReached; }

    public GameObject tower;
    public GameObject templateSquare;
    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite greenSprite;

    public Sprite horizontalPath;
    public Sprite turn_downLeft;
    public Sprite turn_upLeft;
    public Sprite turn_downRight;
    public Sprite turn_upRight;
    public Sprite verticalPath;

    private int startYIndex;
    private int endYIndex;
    private GameObject start;
    private GameObject end;
    private GameObject lastTileClicked;
    private GameObject twoTilesAgo;

    public GameObject GetStartTile() { return start; }
    public GameObject GetEndTile() { return end; }

    TowerBuilder towerbuilder;
    private List<int[]> towers;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        LoadingLevelStats();

        DetermineTopLeftXandY();

        TileStartUp();

        // setting up the start and end tiles
        StartEndErrorCheck();
        start = Instantiate(templateSquare, new Vector2(starterTiles[0, startYIndex].transform.position.x - tileDifferential, starterTiles[0, startYIndex].transform.position.y), Quaternion.identity);
        ChangeColor(start, greenSprite);
        end = Instantiate(templateSquare, new Vector2(starterTiles[xTiles-1, endYIndex].transform.position.x + tileDifferential, starterTiles[xTiles - 1, endYIndex].transform.position.y), Quaternion.identity);
        ChangeColor(end, greenSprite);

        // setting first choice available
        lastTileClicked = start;

        // tower initialization
        SetTowersInGrid();
    }

    // Update is called once per frame
    void Update()
    {
        ReachedEnd();

        // if the end has been reached or path tiles have run out, stop path updates
        if (!endHasBeenReached && Input.GetMouseButton(0) && finalPath.Count <= maxPathTiles)
        {
            MouseClickCheck();
        }

        NextPathChoices();

    }

    /// <summary>
    /// Loads all of the level stats in from the TowerBuilder script
    /// </summary>
    public void LoadingLevelStats()
    {
        // linking loader script and launching
        towerbuilder = gameObject.GetComponent<TowerBuilder>();
        towerbuilder.Setter();

        // linking base stats
        xTiles = towerbuilder.xTiles;
        yTiles = towerbuilder.yTiles;
        maxPathTiles = towerbuilder.maxPathTiles;
        startYIndex = towerbuilder.startYindex;
        endYIndex = towerbuilder.endYindex;
    }

    /// <summary>
    /// Sets the values for topLeftY and topLeftX that will build the array
    /// </summary>
    public void DetermineTopLeftXandY()
    {
        // error checking
        if (xTiles < 0)
            xTiles = 5;
        if (yTiles < 0)
            yTiles = 5;
        if (xTiles > 14)
            xTiles = 14;
        if (yTiles > 8)
            yTiles = 8;

        // if x tiles are even
        if (xTiles%2 == 0)
        {
            TopLeftX = xTiles / 2 * -tileDifferential;
        }
        // if x tiles are odd
        else
        {
            TopLeftX = ((xTiles - 1) / 2 * -tileDifferential) - tileDifferential / 2;
        }

        // if y tiles are even
        if (yTiles % 2 == 0)
        {
            TopLeftY = yTiles / 2 * tileDifferential;
        }
        // if y tiles are odd
        else
        {
            TopLeftY = ((yTiles - 1) / 2 * tileDifferential) - tileDifferential / 2;
        }
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
    /// Checks values for start and end y index. If too small, set as 0. If too big, set as max
    /// </summary>
    /// <returns></returns>
    public void StartEndErrorCheck()
    {
        // below 0
        if (startYIndex < 0)
            startYIndex = 0;
        if (endYIndex < 0)
            endYIndex = 0;

        // above max
        if (startYIndex >= yTiles)
            startYIndex = yTiles - 1;
        if (endYIndex >= yTiles)
            endYIndex = yTiles - 1;
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
    /// Pulls tower indices from TowerBuilder script
    /// </summary>
    public void SetTowersInGrid()
    {
        // Setting towers into matrix
        towers = towerbuilder.towerIndices;

        for (int i = 0; i < towers.Count; i++)
        {
            GameObject towerSave = Instantiate(tower, starterTiles[towers[i][0], towers[i][1]].transform.position, Quaternion.identity);
            Destroy(starterTiles[towers[i][0], towers[i][1]]);
            starterTiles[towers[i][0], towers[i][1]] = towerSave;
        }
    }

    /// <summary>
    /// Check if the end has been reached
    /// </summary>
    public void ReachedEnd()
    {
        int xIndex = -1;
        int yIndex = -1;

        // stores indeces for last tile clicked
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

        // checks if tile is next to the end
        if (xIndex == startUpX.Length - 1 && yIndex == endYIndex && !endHasBeenReached)
        {
            finalPath.Add(lastTileClicked.transform.position);
            finalPath.Add(end.transform.position);
            endHasBeenReached = true;
            ChangeColor(end, horizontalPath);
            SetCorrectSprites(end);
        }
    }

    /// <summary>
    /// Detects mouse click and checks for collision with any boxes
    /// </summary>
    public void MouseClickCheck()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null)
        {
            // checks if tile is valid for path addition
            if (ValidPath(hit.collider.gameObject))
            {
                finalPath.Add(lastTileClicked.transform.position);

                if (twoTilesAgo != null)
                {
                    SetCorrectSprites(hit.collider.gameObject);
                }
                else
                {
                    ChangeColor(start, horizontalPath);
                }

                twoTilesAgo = lastTileClicked;
                lastTileClicked = hit.collider.gameObject;
                ChangeColor(hit.collider.gameObject, greenSprite);
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

        // stores indeces for last tile clicked
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

        // loops through all tiles to determine what the cell should look like
        for (int i = 0; i < startUpX.Length; i++)
        {
            for (int j = 0; j < startUpY.Length; j++)
            {
                // checks if cell is tower
                if (!(starterTiles[i, j].tag == "Tower"))
                {
                    if (starterTiles[i, j].GetComponent<SpriteRenderer>().sprite == greenSprite || starterTiles[i, j] == lastTileClicked || finalPath.Contains(starterTiles[i,j].transform.position))
                    {
                        continue;
                    }
                    else if ((i == xIndex + 1 && j == yIndex || i == xIndex - 1 && j == yIndex || i == xIndex && j == yIndex + 1 || i == xIndex && j == yIndex - 1 || i == 0 && j == startYIndex) && !endHasBeenReached)
                    {
                        starterTiles[i, j].GetComponent<SpriteRenderer>().sprite = blueSprite;
                    }
                    else
                    {
                        starterTiles[i, j].GetComponent<SpriteRenderer>().sprite = redSprite;
                    }
                }
                
            }
        }
    }

    /// <summary>
    /// Sets the correct sprite for the current path
    /// </summary>
    /// <param name="hit"></param>
    public void SetCorrectSprites(GameObject hit)
    {
        // index storage
        int hitX = -5;
        int hitY = -5;
        int lastX = -5;
        int lastY = -5;
        int twoAgoX = -5;
        int twoAgoY = -5;

        // finds the index of the new hit and last tile
        for (int i = 0; i < startUpX.Length; i++)
        {
            for (int j = 0; j < startUpY.Length; j++)
            {
                // stores indeces of hit
                if (starterTiles[i,j] == hit)
                {
                    hitX = i;
                    hitY = j;
                }
                else if (endHasBeenReached)
                {
                    hitX = startUpX.Length;
                    hitY = endYIndex;
                }

                // stores indeces of lastTileClicked
                if (starterTiles[i, j] == lastTileClicked)
                {
                    lastX = i;
                    lastY = j;
                }
                else if (lastTileClicked == start)
                {
                    lastX = -1;
                    lastY = startYIndex;
                }

                // stores indeces for twoTilesAgo
                if (starterTiles[i,j] == twoTilesAgo)
                {
                    twoAgoX = i;
                    twoAgoY = j;
                }
                else if (twoTilesAgo == start)
                {
                    twoAgoX = -1;
                    twoAgoY = startYIndex;
                }
            }
        }

        // ---- finds out where lastTileClicked is compared to the new hit ----
        // __ then right
        if (lastX + 1 == hitX && lastY == hitY)
        {
            // right then right
            if (twoAgoX + 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], horizontalPath);
            }
            // down then right
            else if (twoAgoX == lastX && twoAgoY + 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_downRight);
            }
            // up then right
            else if (twoAgoX == lastX && twoAgoY - 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_upRight);
            }
        }
        // __ then left
        else if (lastX - 1 == hitX && lastY == hitY)
        {
            // left then left
            if (twoAgoX - 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], horizontalPath);
            }
            // down then left
            else if (twoAgoX == lastX && twoAgoY + 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_downLeft);
            }
            // up then left
            else if (twoAgoX == lastX && twoAgoY - 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_upLeft);
            }
        }
        // __ then down
        else if (lastX == hitX && lastY + 1 == hitY)
        {
            // right then down
            if (twoAgoX + 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_upLeft);
            }
            // left then down
            else if (twoAgoX - 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_upRight);
            }
            // down then down
            else if (twoAgoX == lastX && twoAgoY + 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], verticalPath);
            }
        }
        // __ then up
        else if (lastX == hitX && lastY - 1 == hitY)
        {
            // right then up
            if (twoAgoX + 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_downLeft);
            }
            // left then up
            else if (twoAgoX - 1 == lastX && twoAgoY == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], turn_downRight);
            }
            // up then up
            else if (twoAgoX == lastX && twoAgoY - 1 == lastY)
            {
                ChangeColor(starterTiles[lastX, lastY], verticalPath);
            }
        }
    }

    /// <summary>
    /// Goes back one space on the path during path placement
    /// </summary>
    public void BackOnePath()
    {
        ChangeColor(twoTilesAgo, greenSprite);
        ChangeColor(lastTileClicked, blueSprite);
        lastTileClicked = twoTilesAgo;
    }
}
