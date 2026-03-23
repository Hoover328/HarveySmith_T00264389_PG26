using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject button;
    public TestDummy ButtonObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonObject.isPressed)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
    }

   
}
