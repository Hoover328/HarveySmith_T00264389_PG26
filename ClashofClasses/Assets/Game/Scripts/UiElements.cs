using UnityEngine;
using UnityEngine.UI;

public class UiElements : MonoBehaviour
{
    public Slider dashSlider;
    public Slider healthSlider;
    public RectTransform rectTransform;
    public PlayerMovement playerMovement;
    public float duration = 2f;
    float sliderMax = 100f;
    float sliderMin = 0.0f;
    float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
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

        dashSlider.maxValue = sliderMax;
        dashSlider.minValue = sliderMin;

        dashSlider.value = sliderMax;
    }

    // Update is called once per frame
    void Update()
    {
        float barTimer = Mathf.Clamp01(playerMovement.dashTimer / playerMovement.dashCooldown);
        dashSlider.value = (1f - barTimer) * 100f;
    }
}
