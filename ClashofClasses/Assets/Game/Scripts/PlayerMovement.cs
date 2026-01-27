using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform camera;
    public Rigidbody playerRigidBody;
    public float jumpForce = 5f;
    public float dashForce = 2f;
    public float dashCooldown = 5f;
    public float dashTimer = 0f;
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

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
        }

        if (Keyboard.current.shiftKey.isPressed && dashTimer <= 0f)
        {
            Vector3 camForward = camera.forward;
            Vector3 camRight = camera.right;

            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 dashDirection = Vector3.zero;

            if (Keyboard.current.wKey.isPressed)
            {
                dashDirection += camForward;
            }

            if (Keyboard.current.sKey.isPressed)
            {
                dashDirection -= camForward;
            }
             

            if (Keyboard.current.aKey.isPressed)
            {
                dashDirection -= camRight;
            }
               

            if (Keyboard.current.dKey.isPressed)
            {
                dashDirection += camRight;
            }

            if (dashDirection != Vector3.zero)
            {
                playerRigidBody.AddForce(dashDirection.normalized * dashForce, ForceMode.Impulse);
                dashTimer = dashCooldown;
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