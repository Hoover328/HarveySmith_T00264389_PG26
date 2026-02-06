using System;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UIElements;

public class spiderMovement : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public PlayerMovement playerMovement;
    public Rigidbody spiderRb;
    public SpiderDeath spiderDeath;
    public Collider jumpCollider;
    public float jumpForce = 10;
    public float movementSpeed = 1f;
    Boolean notJumping = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!spiderDeath.dead)
        {
            Vector3 direction = transform.position - player.position;
            if (notJumping)
            {
                direction.y = 0f;
            }
            if (direction.sqrMagnitude > 0.001f)
                transform.rotation = Quaternion.LookRotation(direction);

            transform.position -= transform.forward * movementSpeed * Time.deltaTime;

        }
    }

     void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player") && !playerMovement.isGrounded)
        {
           notJumping = false;
           movementSpeed = 30f;
           animator.SetTrigger("isJumping");

        }
    } 
}
