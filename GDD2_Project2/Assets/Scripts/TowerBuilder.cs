using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public static int currentLevel;

    public int setLevel;
    public List<int[]> towerIndices = new List<int[]>();
    public List<float> towerRanges = new List<float>();
    public int xTiles;
    public int yTiles;
    public int maxPathTiles;
    public int startYindex;
    public int endYindex;

    public float timePerSpawn;
    public int numberOfEnemies;
    public int enemyHP;


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
            case 6:
                Level6Towers();
                break;
            case 7:
                Level7Towers();
                break;
            case 8:
                Level8Towers();
                break;
            case 9:
                Level9Towers();
                break;
            case 10:
                Level10Towers();
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
        
        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);

        // starter values
        xTiles = 5;
        yTiles = 4;
        maxPathTiles = 10;
        startYindex = 2;
        endYindex = 2;

        // enemy values
        numberOfEnemies = 4;
        timePerSpawn = 2.7f;
        enemyHP = 10;
    }

    public void Level2Towers()
    {
        // towers
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 4, 5 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        xTiles = 7;
        yTiles = 7;
        maxPathTiles = 19;
        startYindex = 3;
        endYindex = 3;

        // enemy values
        timePerSpawn = 1.3f;
        numberOfEnemies = 6;
        enemyHP = 10;
    }

    public void Level3Towers()
    {
        // towers
        towerIndices.Add(new int[] { 3, 1 });
        towerIndices.Add(new int[] { 3, 3 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        xTiles = 7;
        yTiles = 5;
        maxPathTiles = 19;
        startYindex = 2;
        endYindex = 2;

        // enemy values
        timePerSpawn = 1.2f;
        numberOfEnemies = 7;
        enemyHP = 10;
    }

    public void Level4Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 5 });
        towerIndices.Add(new int[] { 3, 5 });
        towerIndices.Add(new int[] { 5, 5 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        xTiles = 7;
        yTiles = 7;
        maxPathTiles = 17;
        startYindex = 1;
        endYindex = 1;

        // enemy values
        timePerSpawn = .8f;
        numberOfEnemies = 8;
        enemyHP = 10;
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

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        yTiles = 7;
        xTiles = 9;
        maxPathTiles = 20;
        startYindex = 0;
        endYindex = 5;

        // enemy values
        timePerSpawn = .98f;
        numberOfEnemies = 11;
        enemyHP = 10;
    }

    public void Level6Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 1 });
        towerIndices.Add(new int[] { 1, 3 });
        towerIndices.Add(new int[] { 3, 1 });
        towerIndices.Add(new int[] { 3, 3 });
        towerIndices.Add(new int[] { 5, 3 });
        towerIndices.Add(new int[] { 5, 5 });
        towerIndices.Add(new int[] { 7, 3 });
        towerIndices.Add(new int[] { 7, 5 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        yTiles = 7;
        xTiles = 9;
        startYindex = 0;
        endYindex = 6;
        maxPathTiles = 23;

        // enemy values
        timePerSpawn = .3f;
        numberOfEnemies = 20;
        enemyHP = 10;
    }

    public void Level7Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 3 });
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 2, 5 });
        towerIndices.Add(new int[] { 3, 3 });
        towerIndices.Add(new int[] { 4, 1 });
        towerIndices.Add(new int[] { 4, 5 });
        towerIndices.Add(new int[] { 5, 3 });
        towerIndices.Add(new int[] { 8, 3 });
        towerIndices.Add(new int[] { 9, 1 });
        towerIndices.Add(new int[] { 9, 5 });
        towerIndices.Add(new int[] { 10, 3 });
        towerIndices.Add(new int[] { 11, 1 });
        towerIndices.Add(new int[] { 11, 5 });
        towerIndices.Add(new int[] { 12, 3 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        yTiles = 7;
        xTiles = 14;
        maxPathTiles = 48;
        startYindex = 3;
        endYindex = 3;

        // enemy values
        timePerSpawn = .25f;
        numberOfEnemies = 50;
        enemyHP = 10;
    }

    public void Level8Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 1 });
        towerIndices.Add(new int[] { 1, 3 });
        towerIndices.Add(new int[] { 1, 5 });
        towerIndices.Add(new int[] { 3, 1 });
        towerIndices.Add(new int[] { 3, 3 });
        towerIndices.Add(new int[] { 3, 5 });
        towerIndices.Add(new int[] { 5, 1 });
        towerIndices.Add(new int[] { 5, 5 });
        towerIndices.Add(new int[] { 6, 1 });
        towerIndices.Add(new int[] { 6, 5 });
        towerIndices.Add(new int[] { 8, 1 });
        towerIndices.Add(new int[] { 8, 3 });
        towerIndices.Add(new int[] { 8, 5 });
        towerIndices.Add(new int[] { 10, 1 });
        towerIndices.Add(new int[] { 10, 3 });
        towerIndices.Add(new int[] { 10, 5 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        yTiles = 7;
        xTiles = 12;
        maxPathTiles = 22;
        startYindex = 3;
        endYindex = 3;

        // enemy values
        timePerSpawn = .5f;
        numberOfEnemies = 300;
        enemyHP = 10;
    }

    public void Level9Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 1 });
        towerIndices.Add(new int[] { 1, 5 });
        towerIndices.Add(new int[] { 3, 0 });
        towerIndices.Add(new int[] { 3, 6 });
        towerIndices.Add(new int[] { 4, 0 });
        towerIndices.Add(new int[] { 4, 6 });
        towerIndices.Add(new int[] { 5, 0 });
        towerIndices.Add(new int[] { 5, 6 });
        towerIndices.Add(new int[] { 6, 0 });
        towerIndices.Add(new int[] { 6, 6 });
        towerIndices.Add(new int[] { 7, 0 });
        towerIndices.Add(new int[] { 7, 6 });
        towerIndices.Add(new int[] { 8, 0 });
        towerIndices.Add(new int[] { 8, 6 });
        towerIndices.Add(new int[] { 10, 1 });
        towerIndices.Add(new int[] { 10, 5 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);

        // starter values
        yTiles = 7;
        xTiles = 12;
        maxPathTiles = 41;
        startYindex = 3;
        endYindex = 3;

        // enemy values
        timePerSpawn = .3f;
        numberOfEnemies = 100;

    }

    public void Level10Towers()
    {
        // towers
        towerIndices.Add(new int[] { 1, 0 });
        towerIndices.Add(new int[] { 1, 2 });
        towerIndices.Add(new int[] { 3, 0 });
        towerIndices.Add(new int[] { 3, 2 });
        towerIndices.Add(new int[] { 3, 4 });
        towerIndices.Add(new int[] { 5, 2 });
        towerIndices.Add(new int[] { 5, 4 });
        towerIndices.Add(new int[] { 5, 6 });
        towerIndices.Add(new int[] { 7, 2 });
        towerIndices.Add(new int[] { 7, 4 });
        towerIndices.Add(new int[] { 7, 6 });
        towerIndices.Add(new int[] { 9, 0 });
        towerIndices.Add(new int[] { 9, 2 });
        towerIndices.Add(new int[] { 9, 4 });
        towerIndices.Add(new int[] { 11, 0 });
        towerIndices.Add(new int[] { 11, 2 });
        towerIndices.Add(new int[] { 13, 0 });
        towerIndices.Add(new int[] { 13, 2 });
        towerIndices.Add(new int[] { 13, 4 });
        towerIndices.Add(new int[] { 13, 6 });

        //ranges (add in same order as towers)
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);
        towerRanges.Add(1.5f);


        // starter values
        yTiles = 8;
        xTiles = 16;
        maxPathTiles = 34;
        startYindex = 1;
        endYindex = 7;

        // enemy values
        timePerSpawn = .3f;
        numberOfEnemies = 100;
        enemyHP = 10;
    }
}
