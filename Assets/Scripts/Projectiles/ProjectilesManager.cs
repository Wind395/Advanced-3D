using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ProjectilesManager : MonoBehaviour
{

    public GameObject normalProjectile;
    public GameObject fireProjectile;

    public GameObject _firePos;
    public GameObject spellCircleFire;

    public GameObject[] targets;

    private NormalProjectilePooling _normalProjectilePooling;
    private FireProjectilePooling _fireProjectilePooling;

    [SerializeField] private GameObject player;

    void Start()
    {
        _normalProjectilePooling = GetComponent<NormalProjectilePooling>();
        _fireProjectilePooling = GetComponent<FireProjectilePooling>();
    }

    public IEnumerator LaunchNormalProjectile()
    {
        spellCircleFire.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _normalProjectilePooling.GetProjectile(_firePos);
        yield return new WaitForSeconds(0.5f);
        _normalProjectilePooling.GetProjectile(_firePos);
        yield return new WaitForSeconds(1f);
        spellCircleFire.SetActive(false);
        
    }

    public IEnumerator LaunchFireBall()
    {
        spellCircleFire.SetActive(true);
        yield return new WaitForSeconds(2);
        _fireProjectilePooling.GetObject(_firePos);
        yield return new WaitForSeconds(1);
        spellCircleFire.SetActive(false);

    }

}
