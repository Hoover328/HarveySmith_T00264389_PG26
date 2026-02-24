using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Rigidbody projectileRb;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireInterval = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShootCoroutine());
    }


    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectileRb.angularVelocity = firePoint.forward * fireForce;
    }

}
