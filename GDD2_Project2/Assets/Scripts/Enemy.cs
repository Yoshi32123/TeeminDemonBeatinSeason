using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int maxHealth;
    int health;
    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += speed;
        transform.position = position;


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
