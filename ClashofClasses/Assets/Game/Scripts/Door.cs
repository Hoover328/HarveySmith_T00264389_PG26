using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public GameObject button;
    public List<TestDummy> ButtonObjects = new List<TestDummy>();
    public List<SpiderDeath> Spiders = new List<SpiderDeath>();
    public bool isEnemyDoor = false;
    public GameObject Cat;
    public bool doorOpen = false;
    private bool soundFireOnce = true;
    public AudioSource doorOpenSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemyDoor)
        {
            bool allPressed = true;

            foreach (TestDummy testDummy in ButtonObjects)
            {
                if (!testDummy.isPressed)
                {
                    allPressed = false;
                    break;
                }
            }

            if (allPressed)
            {
                transform.position += Vector3.down * Time.deltaTime;
                if (soundFireOnce)
                {
                    doorOpenSound.Play();
                    soundFireOnce = false;
                }
                doorOpen = true;
            }
        }

        else
        {
            bool allPressed = true;

            foreach (SpiderDeath spider in Spiders)
            {
                if (!spider.buttonPressed)
                {
                    allPressed = false;
                    break;
                }
            }

            if (allPressed)
            {
                bool fireOnce = true;
                transform.position += Vector3.down * Time.deltaTime;
                if (fireOnce)
                {
                    Cat.transform.position = new Vector3(45.98077f, -9.114f, -304.0461f);
                    fireOnce = false;
                }
                doorOpen = true;
                if (soundFireOnce)
                {
                    doorOpenSound.Play();
                    soundFireOnce = false;
                }
            }
        }

       
    }

   
}
