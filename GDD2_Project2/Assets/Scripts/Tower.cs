using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    [SerializeField] float range = 0.0f;
    [SerializeField] float timeToCoolDown = 0.0f;
    [SerializeField] int damage = 0;
    float cooldownTimer;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        cooldownTimer = timeToCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= (Time.deltaTime * SpeedFunctionality.GameSpeed);
        }

        target = levelManager.GetClosestEnemy(transform.position, range);

        if (target != null)
        {
            if(cooldownTimer <= 0)
            {
                target.GetComponent<Enemy>().TakeDamage(damage);
                cooldownTimer = timeToCoolDown;
            }
            Debug.DrawLine(transform.position, target.transform.position, Color.magenta);
        }
    }
}
