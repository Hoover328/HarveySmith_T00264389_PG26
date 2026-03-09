using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartToMainScene : MonoBehaviour
{
    public string scene;
    public bool isLoader;
    public bool transition;
    public Fade fade;
    public Image fadeImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeImage.enabled = true;
        if (scene == null)
        {
            return;
        }

        if (transition)
        {
            StartCoroutine(fade.FadeInOut());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLoader)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
