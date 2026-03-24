using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public GameObject button;
    public List<TestDummy> ButtonObjects = new List<TestDummy>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

}

    // Update is called once per frame
    void Update()
    {
        bool allPressed = true;

        foreach (TestDummy testDummy in ButtonObjects) {
            if(!testDummy.isPressed)
            {
                allPressed = false;
                break;
            }
        }

        if (allPressed)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }

       
    }

   
}
