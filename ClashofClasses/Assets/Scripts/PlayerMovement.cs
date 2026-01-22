using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform camera; 

    void Update()
    {
        if (Keyboard.current == null)
            return;

        float xAxis = 0f;
        float zAxis = 0f;

        if (Keyboard.current.wKey.isPressed) zAxis += 1;
        if (Keyboard.current.sKey.isPressed) zAxis -= 1;
        if (Keyboard.current.aKey.isPressed) xAxis -= 1;
        if (Keyboard.current.dKey.isPressed) xAxis += 1;

        Vector3 input = new Vector3(xAxis, 0f, zAxis).normalized;

        // Camera-relative directions
        Vector3 vertical = camera.forward;
        Vector3 horrizontal = camera.right;


        vertical.y = 0f;
        horrizontal.y = 0f;

        vertical.Normalize();
        horrizontal.Normalize();

        Vector3 move = vertical * input.z + horrizontal * input.x;

        transform.position += move * speed * Time.deltaTime;
    }
}