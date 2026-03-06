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
    public GameObject NPCObject;
    public Image sword1;
    public Image sword2;
    public Image sword3;
    public Image textBox;
    public TextMeshProUGUI textMeshPro;
    int selectedSword;
    public PlayerCamera playerCamera;
    public float fadeTime = 3f;
    public bool isDialogue = false;
    public Slider healthBar;
    public Slider staminaBar;
    public Camera playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        noInputs = false;
        NpcSprite.enabled = false;
        textBox.enabled = false;
        textMeshPro.enabled = false;

        


    }

    // Update is called once per frame
    void Update()
    {
        if (NPCObject == null)
            return;

        if (Npc == null)
            return;

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
            textBox.enabled = true;
            textMeshPro.enabled = true;
            NPCObject.SetActive(false);
            healthBar.gameObject.SetActive(false);
            staminaBar.gameObject.SetActive(false);
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
            Vector3 rotation = playerCamera.transform.eulerAngles;
            rotation.x = 0f;
            playerCamera.transform.eulerAngles = rotation;

            playerCamera.canMoveCamera = false;


        }

        if (!Npc.talking)
        {
            yield return new WaitForSeconds(0.5f);
            Npc.fadeTransition = false;
            yield return new WaitForSeconds(0.5f);
            noInputs = false;
            isDialogue = false;
            NpcSprite.enabled = false;
            textBox.enabled = false;
            textMeshPro.enabled = false;
            NPCObject.SetActive(true);
            healthBar.gameObject.SetActive(true);
            staminaBar.gameObject.SetActive(true);
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


            playerCamera.canMoveCamera = true;

        }
    }

  
}
