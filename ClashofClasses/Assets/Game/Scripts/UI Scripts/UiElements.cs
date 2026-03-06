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
    public Image sword1;
    public Image sword2;
    public Image sword3;

    public float duration = 2f;
    float dashSliderMax = 100f;
    float dashSliderMin = 0.0f;
    float healthSliderMax = 100f;
    float currentHealth;
    float healthSliderMin = 0.0f;
    float hurtCoolDown = 2f;
    bool canBeHurt = true;

    public bool uiActive = true;
    int selectedSword;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (uiActive)
        {
            healthSlider.gameObject.SetActive(true);
            dashSlider.gameObject.SetActive(true);
            if (selectedSword == 1)
            {
                sword1.enabled = true;
            }

            if (selectedSword == 2)
            {
                sword2.enabled = true;
            }

            if (selectedSword == 3)
            {
                sword3.enabled = true;
            }
        }

        else
        {
            healthSlider.gameObject.SetActive(false);
            dashSlider.gameObject.SetActive(false);
            if (sword1.IsActive())
            {
                selectedSword = 1;
                sword1.enabled = false;
            }

            if (sword2.IsActive())
            {
                selectedSword = 2;
                sword2.enabled = false;
            }

            if (sword3.IsActive())
            {
                selectedSword = 3;
                sword3.enabled = false;
            }
        }
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

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.CompareTag("Enemy") && canBeHurt)
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
