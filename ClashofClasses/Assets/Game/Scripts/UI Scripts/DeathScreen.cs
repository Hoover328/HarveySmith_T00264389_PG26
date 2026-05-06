using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : Fade
{
    [SerializeField] private UiElements uiElements;
    [SerializeField] private  Image endScreen;
    [SerializeField] private TextMeshProUGUI endText;

    private bool fireOnce = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endScreen.enabled = false;
        endText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        uiElements.healthDepleted += startDeath;
    }

    public void startDeath()
    {
        if (fireOnce)
        {
            StartCoroutine(death());
            fireOnce = false;
        }
    }

    public IEnumerator death()
    {
        startFadeTransition(0f, 1f);
        yield return new WaitForSeconds(fadeDelay);
        endScreen.enabled = true;
        endText.enabled = true;
  
    }
}
