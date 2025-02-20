using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FireProjectilePooling : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize = 10;
    private List<GameObject> projectilePool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectilePool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    public void GetObject(GameObject _firePos)
    {
        var getProjectile = projectilePool.FirstOrDefault(x => !x.activeSelf);
        if (getProjectile != null)
        {
            getProjectile.transform.position = _firePos.transform.position;
            getProjectile.transform.rotation = _firePos.transform.rotation;
            getProjectile.SetActive(true);
        }
        else
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.SetActive(false);
            projectilePool.Add(newProjectile);
        }
    }

    public void ReturnObject(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
