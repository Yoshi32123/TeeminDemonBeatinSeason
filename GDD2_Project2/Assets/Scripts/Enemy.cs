using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] int maxHealth;
    [SerializeField] float predictiveRadius; //how far away from the exact center of the tile does the enemy need to be before seeking out the next tile?
    int health = 10;
    public int GetHealth() { return health; }

    Vector3 position;
    Vector3 direction;
    Vector3 next;
    List<Vector3> pathway = new List<Vector3>();

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

        direction = Vector3.Normalize(next - position);
        position += direction * speed;
        transform.position = position;

        if(Vector3.SqrMagnitude(next - position) < predictiveRadius * predictiveRadius)
        {
            next = pathway[pathway.IndexOf(next) + 1];
        }

    }

    public void SetPathway(List<Vector3> path)
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
