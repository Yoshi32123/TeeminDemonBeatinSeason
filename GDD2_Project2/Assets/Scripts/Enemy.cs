using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 0.0f;
    [SerializeField] float predictiveRadius = 0.0f; //how far away from the exact center of the tile does the enemy need to be before seeking out the next tile?

    [Header("Gameplay")]
    [SerializeField] int maxHealth = 0;
    public static int scorePerKill = 100;
    public float health = 10;

    [Header("Demon Sprites")]
    [SerializeField] Sprite facingFront;
    [SerializeField] Sprite facingLeft;
    [SerializeField] Sprite facingRight;
    [SerializeField] Sprite facingBack;

    Vector2 position;
    Vector2 direction;

    Vector2 next;
    List<Vector2> pathway = new List<Vector2>();

    bool hasReachedEnd = false;
    public bool GetHasReachedEnd() { return hasReachedEnd; }

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
        position += direction.normalized * speed * SpeedFunctionality.CurrentGameSpeed;
        transform.position = position;

        if(Vector3.SqrMagnitude(next - position) < predictiveRadius * predictiveRadius)
        {
            if (next == pathway[pathway.Count - 1])
            {
                hasReachedEnd = true;
            }
            else
            {
                next = pathway[pathway.IndexOf(next) + 1];
            }
        }

        ChangeSprite();
    }

    public void SetPathway(List<Vector2> path)
    {
        pathway = path;
        next = pathway[0];
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        SetColor();
    }


    /// <summary>
    /// this method is just to show damage for testing purposes
    /// it can and should be removed once art is in
    /// </summary>
    public void SetColor()
    {
        Color newColor = new Color(1.0f, 1.0f - (1.0f / health), 1.0f - (1.0f / health));
        gameObject.GetComponent<SpriteRenderer>().material.color = newColor;
    }

    /// <summary>
    /// Changes the sprite based on the direction that the object is facing
    /// </summary>
    public void ChangeSprite()
    {
        if (direction.x >= Mathf.Sin(Mathf.PI * 45 / 180))
        {
            // facing right
            gameObject.GetComponent<SpriteRenderer>().sprite = facingRight;
        }
        else if (direction.x <= -Mathf.Sin(Mathf.PI * 45 / 180))
        {
            // facing left
            gameObject.GetComponent<SpriteRenderer>().sprite = facingLeft;
        }
        else if (direction.y >= Mathf.Sin(Mathf.PI * 45 / 180))
        {
            // facing back
            gameObject.GetComponent<SpriteRenderer>().sprite = facingBack;
        }
        else if(direction.y <= -Mathf.Sin(Mathf.PI * 45 / 180))
        {
            // facing forward
            gameObject.GetComponent<SpriteRenderer>().sprite = facingFront;
        }
    }
}
