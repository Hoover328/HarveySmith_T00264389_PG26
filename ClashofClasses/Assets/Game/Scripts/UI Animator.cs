using UnityEngine;
using UnityEngine.InputSystem;

public class UIAnimator : MonoBehaviour
{
    public Animator animator;
    public PlayerAttack playerAttack;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && playerAttack.cooldownTimer <= 0) 
        {
           
            animator.SetTrigger("Attack");
        }
    }
}
