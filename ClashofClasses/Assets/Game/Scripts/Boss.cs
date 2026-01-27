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

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            StartCoroutine(HitCooldown());
            bossHealth = -1;

        }

        if (bossHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

    IEnumerator HitCooldown()
    {
        canBeHit = false;

        // visual feedback
        changeColor.material.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        changeColor.material.color = defaultColor;

        // remaining cooldown
        yield return new WaitForSeconds(hitCooldown - 0.15f);
        canBeHit = true;
    }
}

