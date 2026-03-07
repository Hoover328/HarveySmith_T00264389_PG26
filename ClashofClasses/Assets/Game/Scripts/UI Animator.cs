using UnityEngine;
using UnityEngine.InputSystem;

public class UIAnimator1 : MonoBehaviour
{
    private Animator animator;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();

    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && playerAttack.cooldownTimer <= 0) 
        {

            animator.SetTrigger("Attack");
        }


    }
}
