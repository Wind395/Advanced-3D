using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectiles
{

    private FireProjectilePooling _fireProjectilePooling;

    protected override void Start()
    {
        base.Start();
        _fireProjectilePooling = GameObject.Find("ProjectilesManager").GetComponent<FireProjectilePooling>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override IEnumerator MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (_fireProjectilePooling == null)
        {
            Debug.Log("ProjectilePooling is null");
        }
        yield return new WaitForSeconds(3);
        _fireProjectilePooling.ReturnObject(gameObject);
    }

    public override void MoveTowardsEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targets[0].transform.position) < 0.1f)
        {
            _fireProjectilePooling.ReturnObject(gameObject);
        }
    }


}
