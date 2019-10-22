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
    private bool OverlayGenerated = false;

    // Start is called before the first frame update
    void Start()
    {
        LevelManagerScript = TileManagerGO.GetComponent<LevelManager>();
        OverlayGenerated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManagerScript.win && !OverlayGenerated)
        {
            WinCanvas.SetActive(true);

            if (LevelManagerScript.stars == 3)
            {
                //3 stars

                //need to convert world space to ui space so it gets positioned correctly no matter the screen aspect ratio
                Instantiate(pref_star, 
                            Camera.main.WorldToScreenPoint(new Vector2(-2, 0)), 
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);

                Instantiate(pref_star,
                            Camera.main.WorldToScreenPoint(new Vector2(0, 0)),
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);

                Instantiate(pref_star,
                            Camera.main.WorldToScreenPoint(new Vector2(2, 0)),
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);
            }
            else if (LevelManagerScript.stars == 2)
            {
                //2 stars
                Instantiate(pref_star,
                            Camera.main.WorldToScreenPoint(new Vector2(-1, 0)),
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);

                Instantiate(pref_star,
                            Camera.main.WorldToScreenPoint(new Vector2(1, 0)),
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);
            }
            else if (LevelManagerScript.stars == 1)
            {
                //1 star
                Instantiate(pref_star,
                            Camera.main.WorldToScreenPoint(new Vector2(0, 0)),
                            Quaternion.identity)
                    .transform.SetParent(WinCanvas.transform);
            }

            OverlayGenerated = true;
        }
        else if (LevelManagerScript.health <= 0)
        {
            LoseCanvas.SetActive(true);
            OverlayGenerated = true;
        }
    }
}
