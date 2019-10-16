using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    public List<int[]> towerIndices = new List<int[]>();

    public int currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setter()
    {
        switch (currentLevel)
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
                // joe mama
                break;
        }
    }

    public void Level1Towers()
    {
        towerIndices.Add(new int[] { 2, 1 });
    }

    public void Level2Towers()
    {
        towerIndices.Add(new int[] { 2, 1 });
        towerIndices.Add(new int[] { 2, 3 });
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
