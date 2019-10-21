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

    int rangeIndicatorDivisions = 30;

    GameObject target;

    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("TileManager").GetComponent<LevelManager>();
        line = gameObject.GetComponent<LineRenderer>();
        cooldownTimer = timeToCoolDown;
        DrawRange();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.GetEndHasBeenReached())
        {
            ClearRange();
        }

        if(cooldownTimer > 0)
        {
            cooldownTimer -= (Time.deltaTime * SpeedFunctionality.GameSpeed);
        }

        target = levelManager.GetPriorityTarget(transform.position, range);

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

    void DrawRange()
    {
        float x;
        float y;

        line.positionCount = rangeIndicatorDivisions + 1;

        float angle = 0.0f;
        for(int i = 0; i <= rangeIndicatorDivisions; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * range;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * range;

            line.SetPosition(i, new Vector3(x, y, -2.0f));

            angle += (360f / rangeIndicatorDivisions);
        }
    }

    void ClearRange()
    {
        line.positionCount = 0;
    }
}
