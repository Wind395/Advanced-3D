using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour
{
    public float speed;
    public float damage;
    public float distance;
    
    protected GameObject[] targets;

    protected virtual void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected virtual void Update()
    {
        foreach (GameObject target in targets)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < distance)
            {
                MoveTowardsEnemy();
            }
        }
        
        StartCoroutine(MoveProjectile());
    }

    public virtual IEnumerator MoveProjectile()
    {
        yield return null;
    }

    public virtual void MoveTowardsEnemy(){}
}
