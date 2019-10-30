using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject target;
    public void SetTarget(GameObject t) { target = t; }
    Vector2 position;
    Vector2 direction;
    float turnSlerp = 0.0f;
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float turnSpeed;
    float hitRange = 0.1f;
    // Start is called before the first frame update
    protected void Start()
    {
        position = transform.position;
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
        CheckHit();
    }

    protected void Move()
    {
        if (target != null)
        {
            float angle = Mathf.Atan2((target.transform.position - transform.position).y,
                (target.transform.position - transform.position).x)
                * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0,0,angle);
            transform.rotation = Quaternion.Slerp(transform.transform.rotation, targetRotation, turnSlerp);
            turnSlerp += Time.deltaTime * SpeedFunctionality.CurrentGameSpeed * turnSpeed;
        }

        position += (Vector2)transform.right * speed * Time.deltaTime * SpeedFunctionality.CurrentGameSpeed;
        transform.position = position;
    }

    private void CheckHit()
    {
        if(target != null && (target.transform.position - transform.position).sqrMagnitude < hitRange * hitRange)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
