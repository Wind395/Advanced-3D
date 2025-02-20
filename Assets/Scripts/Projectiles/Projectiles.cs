using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour
{

    public float speed;
    public float damage;
    public float distance;
    
    private GameObject[] targets;

    private NormalProjectilePooling projectilePooling;

    protected virtual void Start()
    {
        projectilePooling = GameObject.Find("ProjectilesManager").GetComponent<NormalProjectilePooling>();
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

    public IEnumerator MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (projectilePooling == null)
        {
            Debug.Log("ProjectilePooling is null");
        }
        yield return new WaitForSeconds(3);
        projectilePooling.ReturnProjectile(gameObject);
    }

    public void MoveTowardsEnemy()
    {
        //Vector3 direction = targets[0].transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targets[0].transform.position) < 0.1f)
        {
            projectilePooling.ReturnProjectile(gameObject);
        }
    }

    protected abstract void OnHit();
}
