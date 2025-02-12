using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour
{

    public float speed;
    public float damage;
    
    private GameObject[] targets;

    protected virtual void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
    }

    protected virtual void Update()
    {
        
        Debug.Log("Enemy Found: " + targets.Length);
        if (targets.Length > 0)
        {
            MoveTowardsEnemy();
        }
        MoveProjectile();
    }

    public void MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void MoveTowardsEnemy()
    {
        //Vector3 direction = targets[0].transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targets[0].transform.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void OnHit();
}
