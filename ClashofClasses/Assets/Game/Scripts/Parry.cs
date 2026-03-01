using UnityEngine;

public class Parry : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider parry)
    {
        if (parry.CompareTag("Attack"))
        {
            FireProjectile projectile = GetComponent<FireProjectile>();

            if (projectile != null)
            {
                projectile.SetDirection(Camera.main.transform.forward);
            }

            gameObject.tag = "Attack";

        }
    }
}
