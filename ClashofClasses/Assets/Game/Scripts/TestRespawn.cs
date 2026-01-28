using UnityEngine;
using UnityEngine.InputSystem;

public class TestRespawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.isPressed)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
