using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FinalState : MonoBehaviour
{
    public List<GameObject> HouseItems = new List<GameObject>();
    public TextFill textFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textFill.finalState)
        {
            foreach (var item in HouseItems)
            {
                item.SetActive(false);
            }
        }
    }
}
