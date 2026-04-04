using littleDog;
using UnityEngine;

public class SpiderSight : MonoBehaviour
{
    public bool canSee = false;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider user)
    {
        if (user.CompareTag("Player"))
        {
            animator.SetTrigger("isWalking");
            canSee = true;
            
        }

            
      
    }

    public void OnTriggerExit(Collider user)
    {
        if (user.CompareTag("Player"))
        {
            animator.SetTrigger("default");
            canSee = false;
        }
    }
}
