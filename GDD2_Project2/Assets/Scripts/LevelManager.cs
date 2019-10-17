using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] GameObject pref_Enemy = null;

    TileManager tileManager;

    float time;
    [SerializeField] float timePerSpawn = 0.0f;

    [SerializeField] int numberOfEnemies = 0; //how many enemies in total for this level?
    int currentEnemies = 0; //how many enemies have we spawned at any given time

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tileManager.GetEndHasBeenReached())
        {
            time -= Time.deltaTime;
            if (time <= 0 && currentEnemies < numberOfEnemies)
            {
                Vector3 startPosition = tileManager.GetStartTile().transform.position;
                GameObject newEnemy = Instantiate(
                    pref_Enemy, 
                    new Vector3(startPosition.x, startPosition.y, -0.1f), //need to set z to be closer to camera so enemy doesnt get hidden by tiles
                    Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetPathway(tileManager.finalPath);
                enemies.Add(newEnemy);
                currentEnemies++;
                time = timePerSpawn;
            }

        }
        ClearDeadEnemies();
    }

    void ClearDeadEnemies()
    {
        for(int i = enemies.Count - 1; i >= 0; i--)
        {
            if(enemies[i].GetComponent<Enemy>().GetHealth() <= 0)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }

    public GameObject GetClosestEnemy(Vector3 position, float range)
    {
        Vector3 closest = Vector3.positiveInfinity;
        int closestIndex = int.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            if ((position - enemies[i].transform.position).sqrMagnitude < closest.sqrMagnitude &&
                (position - enemies[i].transform.position).sqrMagnitude <= range * range)
            {
                closest = position - enemies[i].transform.position;
                closestIndex = i;
            }
        }

        if (closestIndex == int.MaxValue)
        {
            return null;
        }
        return enemies[closestIndex];
    }
}
