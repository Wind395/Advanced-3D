using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ProjectilesManager : MonoBehaviour
{

    public GameObject normalProjectile;
    public GameObject fireProjectile;

    public GameObject firePos;
    public GameObject spellCircleFire;

    public GameObject[] targets;

    [SerializeField] private GameObject player;

    public IEnumerator LaunchNormalProjectile(Vector3 position)
    {
        //NormalProjectile projectile = normalProjectile.GetComponent<NormalProjectile>();
        spellCircleFire.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GameObject normalAmmo = Instantiate(normalProjectile, position, player.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        normalAmmo = Instantiate(normalProjectile, position, player.transform.rotation);
        yield return new WaitForSeconds(1f);
        spellCircleFire.SetActive(false);
        
    }

    public IEnumerator LaunchFireBall(Vector3 position)
    {
        //FireProjectile projectile = fireProjectile.GetComponent<FireProjectile>();
        spellCircleFire.SetActive(true);
        yield return new WaitForSeconds(2);
        GameObject fireball = Instantiate(fireProjectile, position, player.transform.rotation);
        yield return new WaitForSeconds(1);
        spellCircleFire.SetActive(false);

    }

}
