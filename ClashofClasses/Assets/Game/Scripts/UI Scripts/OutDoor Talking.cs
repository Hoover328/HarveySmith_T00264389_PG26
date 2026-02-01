using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OutDoorTalking : MonoBehaviour
{
    public bool noInputs = false;
    public NpcBody Npc;
    public PlayerMovement player;
    public Image NpcSprite;
    public Image backround;
    public Image textBox;
    public TextMeshProUGUI textMeshPro;

    public float fadeTime = 3f;
    public bool isDialogue = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noInputs = false;
        NpcSprite.enabled = false;
        backround.enabled = false;
        textBox.enabled = false;
        textMeshPro.enabled = false;
        

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Npc.talking ) 
        {

            StartCoroutine(dialogueTransition());
            noInputs = true;

        }

        if (Npc.talking && Mouse.current.leftButton.wasPressedThisFrame)
        {
          Npc.talking = false;
          Npc.fadeTransition = true;
          StartCoroutine(dialogueTransition());

        }
    }

    IEnumerator dialogueTransition()
    {
        if (Npc.talking)
        {
            yield return new WaitForSeconds(0.1f);
            Npc.fadeTransition = false;
            yield return new WaitForSeconds(1f);
            Npc.spin = false;
            isDialogue = true;
            NpcSprite.enabled = true;
            backround.enabled = true;
            textBox.enabled = true;
            textMeshPro.enabled = true;
        }

        if (!Npc.talking)
        {
            yield return new WaitForSeconds(0.5f);
            Npc.fadeTransition = false;
            yield return new WaitForSeconds(0.5f);
            noInputs = false;
            isDialogue = false;
            NpcSprite.enabled = false;
            backround.enabled = false;
            textBox.enabled = false;
            textMeshPro.enabled = false;
            
        }
    }

  
}
