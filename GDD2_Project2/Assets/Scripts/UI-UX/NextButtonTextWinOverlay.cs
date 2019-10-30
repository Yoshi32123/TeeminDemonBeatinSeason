using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonTextWinOverlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (TowerBuilder.currentLevel == 10)
        {
            GetComponent<Text>().text = "Credits";
        }
    }

}
