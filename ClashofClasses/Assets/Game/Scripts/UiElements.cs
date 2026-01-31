using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class UiElements : MonoBehaviour
{
    public Slider dashSlider;
    public Slider healthSlider;
    public RectTransform rectTransform;
    public PlayerMovement playerMovement;

    public float duration = 2f;
    float dashSliderMax = 100f;
    float dashSliderMin = 0.0f;
    float healthSliderMax = 100f;
    float currentHealth;
    float healthSliderMin = 0.0f;
    float hurtCoolDown = 2f;
    bool canBeHurt = true;
  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = healthSliderMax;

        if (dashSlider == null)
        {
            float percentage = dashSlider.value;
            dashSlider = GetComponent<Slider>();
        }

        if (healthSlider == null)
        {
            float percentage = healthSlider.value;
            dashSlider = GetComponent<Slider>();
        }

        dashSlider.maxValue = dashSliderMax;
        dashSlider.minValue = dashSliderMin;
        healthSlider.maxValue = healthSliderMax;
        healthSlider.minValue = healthSliderMin;

        dashSlider.value = dashSliderMax;
        healthSlider.value = healthSliderMax;
    }

    // Update is called once per frame
    void Update()
    {
        float barTimer = Mathf.Clamp01(playerMovement.dashTimer / playerMovement.dashCooldown);
        dashSlider.value = (1f - barTimer) * 100f;

        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime / hurtCoolDown);

    }

    void OnTriggerStay(Collider hurt)
    {
        if (hurt.CompareTag("Hurt") && canBeHurt)
        {
            StartCoroutine(HitCooldown());
            
        }
    }

    IEnumerator HitCooldown()
    {
        canBeHurt = false;
        currentHealth -= 40f;
        yield return new WaitForSeconds(hurtCoolDown);
        canBeHurt = true;
    }
}
