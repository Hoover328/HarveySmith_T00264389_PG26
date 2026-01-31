using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcBody : MonoBehaviour
{
    public Transform player;
    //bool spin;
    public Rigidbody rb;
    public Collider playerNear;
    bool spin = false;
    float spinForce = 2000f;
    void Start()
    {
        spin = false;
        

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
        
        if (Keyboard.current.gKey.isPressed)
        {
            spin = true;
            rb.AddTorque(Vector3.up * 3000f, ForceMode.Impulse);

            
        }
    }

    void OnTriggerExit(Collider playerNear)
    {
        spin = false;
    }




}
