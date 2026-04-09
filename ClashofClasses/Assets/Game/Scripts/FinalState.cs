using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalState : MonoBehaviour
{
    public List<GameObject> HouseItems = new List<GameObject>();
    public TextFill textFill;
    public bool forceFinalState = false;
    public GameObject Avold;
    public GameObject Cat;
    public AudioSource mainTheme;
    private bool fireOnce = true;
    public Material skybox;
    public Light skyLight;
    public List<Light> lights;
    public List<GameObject> water;
    bool fireOnce2 = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textFill.finalState || forceFinalState)
        {
            if (fireOnce2)
            {
                StartCoroutine(StartFinalState());
                fireOnce2 = false;
            }

        }

        IEnumerator StartFinalState()
        {
            yield return new WaitForSeconds(1f);
            foreach (var item in HouseItems)
            {
                item.SetActive(false);
            }

            if (fireOnce)
            {
                Avold.transform.position = new Vector3(17.14f, -77.7f, 118.34f);
                Cat.transform.position = new Vector3(18.915f, 1.92f, 36.772f);
                fireOnce = false;
            }
            mainTheme.pitch = -0.8f;
            RenderSettings.skybox = skybox;
            skyLight.color = Color.red;
            RenderSettings.fogColor = Color.black;
            textFill.dialougeCheck = 12;


            foreach (var item in water)
            {
                Renderer renderer = item.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material mat = renderer.material;

                    mat.SetColor("_Color", Color.red);
                    mat.SetColor("_TextureColor", Color.red);

                }
            }

            foreach (var item in lights)
            {
                item.color = new Color32(140, 2, 0, 255);
            }
        }

    }
}
