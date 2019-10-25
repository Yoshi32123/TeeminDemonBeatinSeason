using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    [Header("Sprites")]
    [SerializeField] Sprite fireball1;
    [SerializeField] Sprite fireball2;
    [SerializeField] Sprite fireball3;

    private int count;
    private int spriteCount;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        count = 0;
        spriteCount = 1;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        count++;

        if (count > 5)
        {
            count = 0;
            spriteCount++;

            if (spriteCount == 4)
            {
                spriteCount = 1;
            }

            ChangeSprite();
        }
    }

    /// <summary>
    /// Changes the sprite of the fireball. Loops through the different sprites
    /// </summary>
    public void ChangeSprite()
    {
        if (spriteCount == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fireball1;
        }
        else if (spriteCount == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fireball2;
        }
        else if (spriteCount == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fireball3;
        }
    }
}
