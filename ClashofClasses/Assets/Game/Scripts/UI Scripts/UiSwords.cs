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

            sword1Animator.SetTrigger("Attack");
            sword2Animator.SetTrigger("Attack");
            sword3Animator.SetTrigger("Attack");
        }


    }
}
