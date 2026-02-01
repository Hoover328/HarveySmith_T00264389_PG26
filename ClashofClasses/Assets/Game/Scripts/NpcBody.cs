using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcBody : MonoBehaviour
{
    public Transform player;
    public OutDoorTalking OutDoorTalking;
    public Rigidbody rb;
    public Collider playerNear;
    public bool spin = false;
    public bool talking = false;
    public bool fadeTransition;
    float spinForce = 3000f;
    void Start()
    {
        spin = false;
        talking = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = transform.position - player.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f && !spin)
            transform.rotation = Quaternion.LookRotation(direction);

    }

    void OnTriggerStay(Collider playerNear)
    {
        if (!playerNear.CompareTag("Player"))
        {
            return;
        }

        if (OutDoorTalking.noInputs == false && Keyboard.current.eKey.isPressed)
        {
            spin = true;
            talking = true;
            fadeTransition = true;
            rb.AddTorque(Vector3.up * spinForce, ForceMode.Impulse);

            
        }
    }

    void OnTriggerExit(Collider playerNear)
    {
        

    }




}
