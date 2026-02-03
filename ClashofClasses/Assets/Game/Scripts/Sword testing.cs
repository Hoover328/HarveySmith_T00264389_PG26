using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Swordtesting : MonoBehaviour
{
    public Image sword1;
    public Image sword2;
    public Image sword3;
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
    }
}
