using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalProjectile : Projectiles
{

    protected override void OnHit()
    {
        Debug.Log("Normal Projectile Hit!");
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
