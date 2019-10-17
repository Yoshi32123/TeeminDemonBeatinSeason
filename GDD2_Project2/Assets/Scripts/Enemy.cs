using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 0.0f;

    [SerializeField] int maxHealth = 0;
    [SerializeField] float predictiveRadius = 0.0f; //how far away from the exact center of the tile does the enemy need to be before seeking out the next tile?
    int health = 10;
    public int GetHealth() { return health; }

    Vector3 position;
    Vector3 direction;


    Vector3 next;
    List<Vector2> pathway = new List<Vector2>();

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
        direction = next - position;
        position += direction.normalized * speed;
        transform.position = position;

        if(Vector3.SqrMagnitude(next - position) < predictiveRadius * predictiveRadius)
        {
            if (pathway.IndexOf(next) == pathway.Count - 1)
            {
                Debug.Log("enemy made it");
                health = 0;
            }
            else
            {
                next = pathway[pathway.IndexOf(next) + 1];
            }
        }

    }

    public void SetPathway(List<Vector2> path)
    {
        pathway = path;
        next = pathway[0];
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
