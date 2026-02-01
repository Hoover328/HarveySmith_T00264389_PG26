using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public OutDoorTalking OutDoorTalking;
    public float fadeTime = 1f;
    public float fadeDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeImage.enabled = true;
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0f;
        fadeImage.color = fadeColor;
        fadeImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (OutDoorTalking.Npc.fadeTransition == true)
        {

            StartCoroutine(FadeInOut());

        }
    }

    IEnumerator FadeInOut()
    {
        yield return StartCoroutine(FadeTransition(0f, 1f));
        yield return new WaitForSeconds(fadeDelay);
        yield return StartCoroutine(FadeTransition(1f, 0f));
    }

    IEnumerator FadeTransition(float startAlpha, float endAlpha)
    {
        fadeImage.enabled = true;
        float timer = 0f;
        Color fadeColor = fadeImage.color;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            fadeColor.a = Mathf.Lerp(startAlpha, endAlpha, timer / fadeTime);
            fadeImage.color = fadeColor;
            yield return null;
        }

        fadeColor.a = endAlpha;
        fadeImage.color = fadeColor;

        if (endAlpha == 0f)
            fadeImage.enabled = false;
    }
}
