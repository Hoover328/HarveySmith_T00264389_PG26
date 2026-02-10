using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider attackRange)
    {
        animator.SetTrigger("Attacking");
    }


}
