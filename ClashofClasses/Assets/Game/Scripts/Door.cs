using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{

    public List<MonoBehaviour> buttons = new List<MonoBehaviour>();
  //  public List<TestDummy> ButtonObjects = new List<TestDummy>();
  //  public List<SpiderDeath> Spiders = new List<SpiderDeath>();
    public bool isEnemyDoor = false;
    public GameObject Cat;
    public GameObject Avold;
    public bool doorOpen = false;
    private bool soundFireOnce = true;
    public AudioSource doorOpenSound;
    public bool forceAll;
    bool fireOnce = true;
    public AudioSource mainTheme;
    [SerializeField] private bool catDoor = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        bool allPressed = true;

        foreach (MonoBehaviour button in buttons)
        {
            IActivate activatedButton = button as IActivate;
          //  Debug.Log(activatedButton.isActivated());

            if (activatedButton == null || !activatedButton.isActivated())
            {
                allPressed = false;
                break;
            }
        }


        if (allPressed || forceAll)
        {
            doorOpenSound.Play();
            doorOpen = true;
            transform.position += Vector3.down * Time.deltaTime;
            if (fireOnce && catDoor)
            {
                Cat.transform.position = new Vector3(45.98077f, -9.114f, -304.0461f);
                fireOnce = false;
            }
        }
    }

   
}
