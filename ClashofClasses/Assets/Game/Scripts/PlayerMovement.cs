using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public OutDoorTalking OutDoorTalking;
    public Transform camera;
    public Rigidbody playerRigidBody;
    public float jumpForce = 5f;
    public float dashForce = 2f;
    public float dashCooldown = 5f;
    public float dashTimer = 0f;
    public bool isGrounded;
    public bool canMove = true;
    public bool canJump = true;
    Vector3 move;
    private Vector3 velocity;


    private void FixedUpdate()
    {
        Vector3 targetVelocity = velocity;
        Vector3 currentVelocity = playerRigidBody.linearVelocity;

        Vector3 velocityChange = new Vector3(targetVelocity.x - currentVelocity.x, 0f, targetVelocity.z - currentVelocity.z);

        playerRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
    }


    void Update()
    {

       
        Vector3 vertical = camera.forward;
        Vector3 horrizontal = camera.right;

        if (Keyboard.current == null)
            return;

        float xAxis = 0f;
        float zAxis = 0f;

        if (OutDoorTalking.noInputs == false && Keyboard.current.wKey.isPressed && canMove) 
        {
            zAxis += 1;
        }

        if (OutDoorTalking.noInputs == false && Keyboard.current.sKey.isPressed && canMove) 
        { 
            zAxis -= 1; 
        }

        if (OutDoorTalking.noInputs == false && Keyboard.current.aKey.isPressed && canMove) 
        {
            xAxis -= 1; 
        }

        if (OutDoorTalking.noInputs == false && Keyboard.current.dKey.isPressed && canMove) 
        { 
            xAxis += 1; 
        }

        Vector3 input = new Vector3(xAxis, 0f, zAxis).normalized;

        vertical.y = 0f;
        horrizontal.y = 0f;

        vertical.Normalize();
        horrizontal.Normalize();

        move = vertical * input.z + horrizontal * input.x;
        velocity = move * speed;

        if (isGrounded && canJump)
        {
            if(OutDoorTalking.noInputs == false && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;
        }

        if (OutDoorTalking.noInputs == false && Keyboard.current.shiftKey.isPressed && dashTimer <= 0f)
        {
            Vector3 camForward = camera.forward;
            Vector3 camRight = camera.right;

            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 dashDirection = Vector3.zero;

            if (OutDoorTalking.noInputs == false && Keyboard.current.wKey.isPressed)
            {
                dashDirection += camForward;
            }

            if (OutDoorTalking.noInputs == false && Keyboard.current.sKey.isPressed)
            {
                dashDirection -= camForward;
            }
             

            if (OutDoorTalking.noInputs == false && Keyboard.current.aKey.isPressed)
            {
                dashDirection -= camRight;
            }
               

            if (OutDoorTalking.noInputs == false && Keyboard.current.dKey.isPressed)
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