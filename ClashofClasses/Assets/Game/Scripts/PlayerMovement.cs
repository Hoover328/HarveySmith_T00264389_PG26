using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform camera;
    public Rigidbody playerRigidBody;
    public float jumpForce = 5f;
    public float dashForce = 2f;
    bool isGrounded;



    void Update()
    {

        // Camera-relative directions
        Vector3 vertical = camera.forward;
        Vector3 horrizontal = camera.right;

        if (Keyboard.current == null)
            return;

        float xAxis = 0f;
        float zAxis = 0f;

        if (Keyboard.current.wKey.isPressed) 
        {
            zAxis += 1;
        }

        if (Keyboard.current.sKey.isPressed) 
        { 
            zAxis -= 1; 
        }

        if (Keyboard.current.aKey.isPressed) 
        {
            xAxis -= 1; 
        }

        if (Keyboard.current.dKey.isPressed) 
        { 
            xAxis += 1; 
        }

        Vector3 input = new Vector3(xAxis, 0f, zAxis).normalized;

        vertical.y = 0f;
        horrizontal.y = 0f;

        vertical.Normalize();
        horrizontal.Normalize();

        Vector3 move = vertical * input.z + horrizontal * input.x;

        transform.position += move * speed * Time.deltaTime;

        if (isGrounded )
        {
            if(Keyboard.current.spaceKey.isPressed)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        if (Keyboard.current.shiftKey.isPressed)
        {
   
            Vector3 camForward = Camera.main.transform.forward;
            Vector3 camRight = Camera.main.transform.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            if (Keyboard.current.wKey.isPressed)
            {
                playerRigidBody.AddForce(camForward * dashForce, ForceMode.Impulse);
            }

            if (Keyboard.current.sKey.isPressed)
            {
                playerRigidBody.AddForce(-camForward * dashForce, ForceMode.Impulse);
            }

            if (Keyboard.current.aKey.isPressed)
            {
                playerRigidBody.AddForce(-camRight * dashForce, ForceMode.Impulse);
            }

            if (Keyboard.current.dKey.isPressed)
            {
                playerRigidBody.AddForce(camRight * dashForce, ForceMode.Impulse);
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}