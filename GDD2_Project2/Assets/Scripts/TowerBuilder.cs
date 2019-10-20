using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static int currentLevel;

    public int setLevel;
    public List<int[]> towerIndices = new List<int[]>();
    public int xTiles;
    public int yTiles;
    public int maxPathTiles;
    public int startYindex;
    public int endYindex;

    public int timePerSpawn;
    public int numberOfEnemies;


    // needs to be Awake() so it can set level before the Setter(). [ Start() will run after Setter() ]
    void Awake()
    {
        if (currentLevel != 0)
        {
            setLevel = currentLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Finds the level stats to be used based on the level input. If not an option, it defaults to the values used in the inspector
    /// </summary>
    public void Setter()
    {
        switch (setLevel)
        {
            case 1:
                Level1Towers();
                break;
            case 2:
                Level2Towers();
                break;
            case 3:
                Level3Towers();
                break;
            case 4:
                Level4Towers();
                break;
            case 5:
                Level5Towers();
                break;
            default:
                // will use inspector values instead
                break;
        }
    }

    public void Level1Towers()
    {
        // towers
        towerIndices.Add(new int[] { 2, 1 });

        // starter values
        xTiles = 5;
        yTiles = 4;
        maxPathTiles = 10;
        startYindex = 2;
        endYindex = 2;

        // level values
        timePerSpawn = 4;
        numberOfEnemies = 4;
    }

    public void Level2Towers()
    {
        // towers
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 2, 3 });

        // starter values
        xTiles = 5;
        yTiles = 6;
        maxPathTiles = 50;
        startYindex = 4;
        endYindex = 4;
    }

    public void Level3Towers()
    {
        towerIndices.Add(new int[] { 2, 1 });
    }

    public void Level4Towers()
    {
        towerIndices.Add(new int[] { 2, 1 });
    }

    public void Level5Towers()
    {
        towerIndices.Add(new int[] { 2, 1 });
    }
}
