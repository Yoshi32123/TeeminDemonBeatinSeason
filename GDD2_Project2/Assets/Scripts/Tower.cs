using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LevelManager levelManager;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        target = levelManager.GetClosestEnemy(transform.position, range);

        if (target != null)
        {
            Debug.DrawLine(transform.position, target.transform.position);
        }
    }
}
