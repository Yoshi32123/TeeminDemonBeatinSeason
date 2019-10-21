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

    public float timePerSpawn;
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

        // enemy values
        numberOfEnemies = 1;
    }

    public void Level2Towers()
    {
        // towers
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 4, 5 });

        // starter values
        xTiles = 7;
        yTiles = 7;
        maxPathTiles = 19;
        startYindex = 3;
        endYindex = 3;

        // enemy values
        timePerSpawn = 2;
        numberOfEnemies = 3;
    }

    public void Level3Towers()
    {
        // towers
        towerIndices.Add(new int[] { 3, 1 });
        towerIndices.Add(new int[] { 3, 3 });

        // starter values
        xTiles = 7;
        yTiles = 5;
        maxPathTiles = 50;
        startYindex = 2;
        endYindex = 2;

        // enemy values
        timePerSpawn = 1.8f;
        numberOfEnemies = 6;
    }

    public void Level4Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 5 });
        towerIndices.Add(new int[] { 3, 5 });
        towerIndices.Add(new int[] { 5, 5 });

        // starter values
        xTiles = 7;
        yTiles = 7;
        maxPathTiles = 17;
        startYindex = 1;
        endYindex = 1;

        // enemy values
        timePerSpawn = 1;
        numberOfEnemies = 8;
    }

    public void Level5Towers()
    {
        // towers
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 4, 1 });
        towerIndices.Add(new int[] { 6, 1 });
        towerIndices.Add(new int[] { 3, 6 });
        towerIndices.Add(new int[] { 4, 6 });
        towerIndices.Add(new int[] { 5, 6 });

        // starter values
        yTiles = 7;
        xTiles = 9;
        maxPathTiles = 20;
        startYindex = 0;
        endYindex = 5;

        // enemy values
        timePerSpawn = .95f;
        numberOfEnemies = 10;
    }
}
