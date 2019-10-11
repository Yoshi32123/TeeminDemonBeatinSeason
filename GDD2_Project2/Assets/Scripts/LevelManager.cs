using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField] GameObject pref_Enemy;

    float time;
    [SerializeField] float timePerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            enemies.Add(Instantiate(pref_Enemy, new Vector3(-10, Random.Range(-5, 5), 0), Quaternion.identity));
            time = timePerSpawn;
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
