using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefabParry;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireInterval = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(fireInterval);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject prefabSpawn;

        if (Random.value < 0.5f)
            prefabSpawn = projectilePrefab;
        else
            prefabSpawn = projectilePrefabParry;

        GameObject projectile = Instantiate(prefabSpawn, firePoint.position, firePoint.rotation);

        FireProjectile script = projectile.GetComponent<FireProjectile>();
        script.SetDirection(firePoint.forward);

    }

}
