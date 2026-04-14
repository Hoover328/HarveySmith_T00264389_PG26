using UnityEngine;
using UnityEngine.InputSystem;

public class UiSwords : MonoBehaviour
{
    public Animator sword1Animator;
    public Animator sword2Animator;
    public Animator sword3Animator;


    public PlayerAttack playerAttack;

  

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && playerAttack.cooldownTimer <= 0)
        {
            if (sword1Animator != null)
            {
                sword1Animator.SetTrigger("Attack");
            }
            if (sword2Animator != null)
            {
                sword2Animator.SetTrigger("Attack");
            }
            if (sword3Animator != null)
            {
                sword3Animator.SetTrigger("Attack");
            }
        }


    }
}
