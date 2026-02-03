using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attack;
   
    public OutDoorTalking OutDoorTalking;


    public float attackCooldown = 10f;
    public float attackDuration = 10f;
    public float cooldownTimer;
    float attackTimer;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (OutDoorTalking.noInputs == false && Mouse.current.leftButton.wasPressedThisFrame && cooldownTimer <= 0f)
        {
            Transform cam = Camera.main.transform;
       

            GameObject atkInstance = Instantiate(attack, cam.position + cam.forward * 1f, cam.rotation);
            Destroy(atkInstance, attackDuration);

            cooldownTimer = attackCooldown;
        }


    }
}
