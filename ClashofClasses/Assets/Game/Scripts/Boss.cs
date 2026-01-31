using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealth = 3;
    Color defaultColor;
    Renderer changeColor;
    public float hitCooldown = 3f;
    bool canBeHit = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeColor = GetComponent<Renderer>();
        defaultColor = changeColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter(Collider attack)
    {
        if (attack.CompareTag("Attack") && canBeHit)
        {
            StartCoroutine(HitCooldown());
            bossHealth = -1;

        }


    }



    IEnumerator HitCooldown()
    {
        canBeHit = false;

   
        changeColor.material.color = Color.red;
        yield return new WaitForSeconds(1f);
        changeColor.material.color = defaultColor;

       
        yield return new WaitForSeconds(hitCooldown - 3f);
        canBeHit = true;
    }
}

