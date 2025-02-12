using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : Projectiles
{
    
    protected override void OnHit()
    {
        Debug.Log("Fire Projectile Hit!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    OnHit();
        //}
    }
}
