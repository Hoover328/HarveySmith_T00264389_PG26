using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 120f;
    public float followSpeed;
    public float maxUp;
    public float maxDown;
    public float cameraHeight;
    float yaw;
    float pitch;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector2 mouse = Mouse.current.delta.ReadValue();

        yaw += mouse.x * mouseSensitivity * Time.deltaTime;
        pitch -= mouse.y * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, maxUp, maxDown);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        
        Vector3 forward = transform.forward;
        forward.y = 0f;

        transform.position = Vector3.Lerp(transform.position, player.position + Vector3.up * cameraHeight,
            followSpeed * Time.deltaTime);

    }

    
}