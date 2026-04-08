using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Footsteps : MonoBehaviour
{
    public AudioSource footsteps;
    public OutDoorTalking OutDoorTalking;
    public PlayerMovement playerMovement;

    bool isMoving;
    public float stepInterval = 0.5f;
    private float stepTimer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        footsteps.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.canMove && playerMovement.isGrounded)
        {
            isMoving = Keyboard.current.wKey.isPressed || Keyboard.current.aKey.isPressed ||
                       Keyboard.current.sKey.isPressed || Keyboard.current.dKey.isPressed;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            stepTimer -= Time.deltaTime; 
            if (stepTimer <= 0f)
            {
                footsteps.pitch = Random.Range(0.8f, 1.2f);
                footsteps.Play();
                stepTimer = stepInterval; 
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}
