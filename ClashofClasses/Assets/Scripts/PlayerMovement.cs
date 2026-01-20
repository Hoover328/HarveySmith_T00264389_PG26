using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null)
            return;

        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            move += Vector3.forward;
        if (Keyboard.current.sKey.isPressed)
            move += Vector3.back;
        if (Keyboard.current.aKey.isPressed)
            move += Vector3.left;
        if (Keyboard.current.dKey.isPressed)
            move += Vector3.right;

        move = move.normalized * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }
}
