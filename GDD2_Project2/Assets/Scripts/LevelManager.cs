using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();

    [Header("Enemies")]
    [SerializeField] GameObject pref_Enemy = null;
    [SerializeField] public float timePerSpawn = 0.0f;
    [SerializeField] public int numberOfEnemies = 0; //how many enemies in total for this level?

    [Header("Health")]
    [SerializeField] public int maxHealth = 100;

    [Header("Score")]
    [SerializeField] Text scoreTxt;
    [SerializeField] GameObject pref_star;
    [SerializeField] bool autoGenStarTresholds;
    [SerializeField] int[] starThresholds;

    TileManager tileManager;

    float enemyTimer = 0;
    int currentEnemies = 0; //how many enemies have we spawned at any given time

    int score = 0;
    public int stars = 0;

    int enemyInteractions = 0; // counts the number of times an enemy is either killed or makes it to the end. Used to tell when level has ended
    bool levelComplete = false;
    public bool win = false;

    int health = 0;
    public void TakeDamage(int damage) { health -= damage; }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();

        if (autoGenStarTresholds)
        {
            starThresholds = new int[3];
            starThresholds[0] = (int)(numberOfEnemies * Enemy.scorePerKill * 0.70f);
            starThresholds[1] = (int)(numberOfEnemies * Enemy.scorePerKill * 0.85f);
            starThresholds[2] = numberOfEnemies * Enemy.scorePerKill;
        }

        scoreTxt.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (tileManager.GetEndHasBeenReached())
        {
            enemyTimer -= Time.deltaTime * SpeedFunctionality.GameSpeed;
            if (enemyTimer <= 0 && currentEnemies < numberOfEnemies)
            {
                Vector3 startPosition = tileManager.GetStartTile().transform.position;
                GameObject newEnemy = Instantiate(
                    pref_Enemy, 
                    new Vector2(startPosition.x, startPosition.y),
                    Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetPathway(tileManager.finalPath);
                enemies.Add(newEnemy);
                currentEnemies++;
                enemyTimer = timePerSpawn;
            }

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Enemy>().GetHasReachedEnd())
                {
                    enemy.GetComponent<Enemy>().health = 0;
                    health--;
                    enemyInteractions++;
                    Debug.Log("health: " + health);
                }
                else if(enemy.GetComponent<Enemy>().health <= 0)
                {
                    score += Enemy.scorePerKill;
                    enemyInteractions++;
                    scoreTxt.text = "Score: " + score;
                }
            }

            if (!levelComplete && health != 0)
            {
                if (enemies.Count == 0 && enemyInteractions == numberOfEnemies)
                {
                    levelComplete = true;
                    if (score >= starThresholds[2])
                    {
                        //3 stars
                        stars = 3;
                        Instantiate(pref_star, new Vector2(-1, 4), Quaternion.identity);
                        Instantiate(pref_star, new Vector2(0, 4), Quaternion.identity);
                        Instantiate(pref_star, new Vector2(1, 4), Quaternion.identity);
                    }
                    else if (score >= starThresholds[1])
                    {
                        //2 stars
                        stars = 2;
                        Instantiate(pref_star, new Vector2(-0.5f, 4), Quaternion.identity);
                        Instantiate(pref_star, new Vector2(0.5f, 4), Quaternion.identity);
                    }
                    else if (score >= starThresholds[0])
                    {
                        //1 star
                        stars = 1;
                        Instantiate(pref_star, new Vector2(1, 4), Quaternion.identity);
                    }
                    else
                    {
                        //no stars
                        stars = 0;
                    }
                    Debug.Log("Stars: " + stars);
                }
            }
            else
            {
                if (health <= 0)
                {
                    win = false;
                }
                else
                {
                    win = true;
                }
            }
            
        }
        ClearDeadEnemies();
    }

    void ClearDeadEnemies()
    {
        for(int i = enemies.Count - 1; i >= 0; i--)
        {
            if(enemies[i].GetComponent<Enemy>().health <= 0)
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

    public void AddScore(int value) { score += value; }
    public bool GetEndHasBeenReached() { return tileManager.GetEndHasBeenReached(); }
}
