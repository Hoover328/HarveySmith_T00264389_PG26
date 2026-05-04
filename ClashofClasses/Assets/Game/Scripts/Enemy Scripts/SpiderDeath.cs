using System;
using UnityEngine;

public class SpiderDeath : MonoBehaviour, IActivate
{

    public Animator animator;
    public PlayerAttack playerAttack;
    public bool isPressed = false;
    public AudioSource hurt;
    public bool dead;
    bool fireOnce = true;

    public event Action OnActivated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            
            animator.SetTrigger("isHit");
            if (fireOnce)
            {
                hurt.Play();
                fireOnce = false;
            }
            isPressed = true;

        }
    }

    public bool isActivated()
    {
        return isPressed;
    }

    void OnTriggerEnter(Collider attack)
    {
        if (attack.CompareTag("Attack"))
        {
            dead = true;
        }
    }


}
