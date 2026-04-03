using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordButtonControl : MonoBehaviour
{
    public List<swordButton> Buttons = new List<swordButton>();
    public Fade fade;
    public Image npc;
    public Image background;
    public Image textBox;
    public TextMeshProUGUI textMeshPro;
    public bool closeMenu = false;
    public TextFill textFill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background.enabled = false;
        foreach (swordButton button in Buttons)
        {
            {
                button.gameObject.SetActive(false);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textFill.dialougeCheck == 6)
        {
            StartCoroutine(MenuEnter());
        }
        if (textFill.dialougeCheck == 7)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            foreach (swordButton button in Buttons)
            {
                if (button.isPressed)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    closeMenu = true;
                    button.isPressed = false;
                   

                    if (closeMenu)
                    {
                        StartCoroutine(MenuExit());
                    }

                }
            
            }
        }
    }

    public IEnumerator MenuEnter()
    {
        closeMenu = false;
        textFill.dialougeCheck = 7;
        StartCoroutine(fade.FadeInOut());
        yield return new WaitForSeconds(1f);
        npc.enabled = false;
        textBox.enabled = false;
        textMeshPro.enabled = false;
        background.enabled = true;
        foreach (swordButton button in Buttons)
        {
            {
                button.gameObject.SetActive(true);
            }

        }
        }
    public IEnumerator MenuExit()
    {
        textFill.dialougeCheck = 8;
        textFill.fireOnce = true;
        StartCoroutine(fade.FadeInOut());
        foreach (swordButton button2 in Buttons)
        {
            {
                button2.gameObject.SetActive(false);
                button2.text.enabled = false;
            }

        }
        yield return new WaitForSeconds(1f);
        npc.enabled = true;
        textBox.enabled = true;
        textMeshPro.enabled = true;
        background.enabled = false;
        
    }


}
