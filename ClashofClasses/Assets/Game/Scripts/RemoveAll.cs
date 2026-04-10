using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAll : MonoBehaviour
{
    public List<GameObject> allObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in allObjects)
        {
            GameObject.Destroy(obj);
        }
    }
}
