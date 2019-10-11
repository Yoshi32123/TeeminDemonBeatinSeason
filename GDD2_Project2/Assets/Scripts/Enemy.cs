using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] int maxHealth;
    int health = 10;
    public int GetHealth() { return health; }

    Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        health = maxHealth;
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        position.x += speed;
        transform.position = position;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("ouchie");
        health -= damage;
        SetColor();
    }


    /// <summary>
    /// this method is just to show damage for testing purposes
    /// it can and should be removed once art is in
    /// </summary>
    void SetColor()
    {
        Color newColor = new Color(1.0f, 1.0f - (1.0f / health), 1.0f - (1.0f / health));
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
    }
}
