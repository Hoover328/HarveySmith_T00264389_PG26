using UnityEngine;

public class Parry : MonoBehaviour
{
    public bool tennisMatchMode = false;
    public bool parry = true;
    public Vector3 enemyPosition =  new Vector3(16.822f, -73.74677f, 125.529f);

    public bool IsParryAttack => gameObject.CompareTag("ParryAttack");
    public bool CanHitBoss => gameObject.CompareTag("CanHitBoss");

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (gameObject.tag == "ParryAttack")
        {
            parry = true;
        }

        else if (gameObject.tag == "CanHitBoss") 
        {
            parry = false;
        }*/
    }

    private void OnTriggerEnter(Collider parry)
    {
        if (parry.CompareTag("Attack") && !tennisMatchMode)
        {
            FireProjectile projectile = GetComponent<FireProjectile>();

            if (projectile != null)
            {
                projectile.SetDirection(Camera.main.transform.forward);
            }

            gameObject.tag = "ParryAttack";

        }

        else if (parry.CompareTag("Attack") && tennisMatchMode)
        {
            FireProjectile projectile = GetComponent<FireProjectile>();

            if (projectile != null)
            {
                projectile.SetDirectionForBoss(enemyPosition);
            }


            gameObject.tag = "CanHitBoss";
        }
    }
}
