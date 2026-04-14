using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Swordtesting : MonoBehaviour
{
    public Image sword1;
    public Image sword2;
    public Image sword3;
    public Rigidbody rigidbody1;
    public FinalState finalState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sword2.enabled = false;
        sword3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Keyboard.current.oKey.isPressed)
        {
            sword1.enabled = false;
            sword2.enabled=true;
            sword3.enabled = false;
        }

        if (Keyboard.current.iKey.isPressed)
        {
            sword1.enabled = true;
            sword2.enabled = false;
            sword3.enabled = false;
        }

        if (Keyboard.current.pKey.isPressed)
        {
            sword3.enabled = true;
            sword2.enabled = false;
            sword1.enabled = false;
        }

        if (Keyboard.current.uKey.isPressed)
        {
            finalState.forceFinalState = true;
        }


        if (Keyboard.current.digit1Key.isPressed)
        {
            rigidbody1.transform.position = new Vector3(46.49377f, -10.19875f, -299.0454f);
        }

        if (Keyboard.current.digit2Key.isPressed)
        {
            rigidbody1.transform.position = new Vector3(31.98f, 1.11f, 67.18f);
        }

        if (Keyboard.current.digit3Key.isPressed)
        {
            rigidbody1.transform.position = new Vector3(15.93426f, -76.86681f, 103.22967f);
        }

    }
}
