using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class swordButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Image sword;
    public TextMeshProUGUI text;
    public bool isPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sword.enabled = false;
        text.enabled = false;
    }

  

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        text.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isPressed = true;
        sword.enabled = true;
    }

    
}
