using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalProjectile : Projectiles
{
    private NormalProjectilePooling _normalProjectilePooling;

    protected override void Start()
    {
        base.Start();
        _normalProjectilePooling = GameObject.Find("ProjectilesManager").GetComponent<NormalProjectilePooling>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override IEnumerator MoveProjectile()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (_normalProjectilePooling == null)
        {
            Debug.Log("ProjectilePooling is null");
        }
        yield return new WaitForSeconds(3);
        _normalProjectilePooling.ReturnProjectile(gameObject);
    }

    public override void MoveTowardsEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targets[0].transform.position) < 0.1f)
        {
            _normalProjectilePooling.ReturnProjectile(gameObject);
        }
    }

    
}
