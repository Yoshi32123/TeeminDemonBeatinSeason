﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();

    [Header("Enemies")]
    [SerializeField] GameObject pref_Enemy = null;
    [SerializeField] float timePerSpawn = 0.0f;
    [SerializeField] int numberOfEnemies = 0; //how many enemies in total for this level?

    [Header("Health")]
    [SerializeField] int maxHealth = 100;

    [Header("Score")]
    [SerializeField] bool autoGenStarTresholds;
    [SerializeField] int[] starThresholds;

    TileManager tileManager;

    float time;
    int currentEnemies = 0; //how many enemies have we spawned at any given time

    int score;
    int stars = 0;

    int health = 0;
    public void TakeDamage(int damage) { health -= damage; }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        health = maxHealth;
        tileManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();

        if (autoGenStarTresholds)
        {
            starThresholds = new int[3];
            starThresholds[0] = (int)(numberOfEnemies * Enemy.scorePerKill * 0.70f);
            starThresholds[1] = (int)(numberOfEnemies * Enemy.scorePerKill * 0.85f);
            starThresholds[2] = numberOfEnemies * Enemy.scorePerKill;

            Debug.Log(starThresholds[0] + "," + starThresholds[1] + "," + starThresholds[2]);
        }
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
                    new Vector2(startPosition.x, startPosition.y),
                    Quaternion.identity);
                newEnemy.GetComponent<Enemy>().SetPathway(tileManager.finalPath);
                enemies.Add(newEnemy);
                currentEnemies++;
                time = timePerSpawn;
            }

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Enemy>().GetHasReachedEnd())
                {
                    enemy.GetComponent<Enemy>().health = 0;
                    health--;
                    Debug.Log("health: " + health);
                }
                else if(enemy.GetComponent<Enemy>().health <= 0)
                {
                    score += Enemy.scorePerKill;
                }
            }

            if(enemies.Count == 0)
            {
                if(score >= starThresholds[2])
                {
                    //3 stars
                    stars = 3;
                }
                else if(score >= starThresholds[1])
                {
                    //2 stars
                    stars = 2;
                }
                else if(score >= starThresholds[0])
                {
                    //1 star
                    stars = 1;
                }
                else
                {
                    //no stars
                    stars = 0;
                }
                Debug.Log("Score: " + score);
                Debug.Log("Stars: " + stars);
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
}
