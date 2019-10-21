using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseBehavior : MonoBehaviour
{
    public GameObject WinCanvas;
    public GameObject LoseCanvas;
    public GameObject TileManagerGO;
    private LevelManager LevelManagerScript;
    [SerializeField] GameObject pref_star;

    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript = TileManagerGO.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManagerScript.win)
        {
            WinCanvas.SetActive(true);

            if (LevelManagerScript.stars == 3)
            {
                //3 stars
                Instantiate(pref_star, new Vector2(-1, 4), Quaternion.identity);
                Instantiate(pref_star, new Vector2(0, 4), Quaternion.identity);
                Instantiate(pref_star, new Vector2(1, 4), Quaternion.identity);
            }
            else if (sLevelManagerScript.stars == 2)
            {
                //2 stars
                Instantiate(pref_star, new Vector2(-0.5f, 4), Quaternion.identity);
                Instantiate(pref_star, new Vector2(0.5f, 4), Quaternion.identity);
            }
            else if (LevelManagerScript.stars ==1)
            {
                //1 star
                Instantiate(pref_star, new Vector2(1, 4), Quaternion.identity);
            }
        }
        else if (LevelManagerScript.lose)
        {
            LoseCanvas.SetActive(true);
        }
    }
}
