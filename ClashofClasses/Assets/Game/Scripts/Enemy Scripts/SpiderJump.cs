using littleDog;
using System;
using UnityEngine;

public class SpiderJump : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;
    public SpiderDeath spiderDeath;
    public Transform player;
    public float jumpForce = 7;
    public Rigidbody spiderRb;
    bool notJumping = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider user)
    {
        if (user.CompareTag("Player") && !playerMovement.isGrounded && !spiderDeath.dead)
        {
            Vector3 direction = transform.position - player.position;
            if (direction.sqrMagnitude > 0.001f)
                transform.rotation = Quaternion.LookRotation(direction);

            //spiderRb.AddForce(-transform.up, ForceMode.Force);
            spiderRb.AddForce(-transform.forward * jumpForce, ForceMode.Force);
            notJumping = false;
            animator.SetTrigger("isJumping");

        }
    }
}
