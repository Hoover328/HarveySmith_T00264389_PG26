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
    public NpcBody Npc2;
    public PlayerMovement player;
    public Image NpcSprite;
    public Image Npc2Sprite;
    public GameObject NPCObject;
    public GameObject NPC2Object;
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
    public TextFill textfill;
    public bool readyToKill = false;
    public bool bossStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        noInputs = false;
        if (textBox != null)
        {
            textBox.enabled = false;
        }
        if (textMeshPro != null)
        {
            textMeshPro.enabled = false;
        }

        if (Npc2Sprite != null)
        {
            Npc2Sprite.enabled = false;
        }

        if (NpcSprite != null)
        {
            NpcSprite.enabled = false;
        }

        if (NPC2Object == null)
        {
            return;
        }

        if (textfill == null)
        {
            return;
        }

        if (Npc2 == null)
        {
            return;
        }

        if (Npc == null)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textfill.dialougeCheck);
        if (Npc.talking)
        {
            readyToKill = false;
        }
           
        if (NPCObject == null)
            return;

        if (Npc == null)
            return;

        if (Npc.talking ) 
        {
       
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
            noInputs = true;

        }

        if (Npc2 != null && Npc2.talking)
        {
            StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));
            noInputs = true;

        }


        if (Npc.talking && textfill.dialougeCheck == 4) 
        {
          Npc.talking = false;
            textfill.dialougeCheck = 5;
          Npc.fadeTransition = true;
          StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));

        }

        if (Npc.talking && textfill.dialougeCheck == 9)
        {
            Npc.talking = false;
            textfill.dialougeCheck = 10;
            Npc.fadeTransition = true;
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));

        }

        if (Npc.talking && textfill.dialougeCheck == 11)
        {
            Npc.talking = false;
            textfill.dialougeCheck = 10;
            Npc.fadeTransition = true;
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));

        }

        if (Npc.talking && textfill.dialougeCheck == 15)
        {
            Npc.talking = false;
            readyToKill = true;
            textfill.dialougeCheck = 10;
            Npc.fadeTransition = true;
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));

        }

        if (Npc.talking && textfill.dialougeCheck == 20)
        {
            Npc.talking = false;
            textfill.dialougeCheck = 21;
            Npc.fadeTransition = true;
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
            bossStart = true;

        }

        if (Npc.talking && textfill.dialougeCheck == 35)
        {
            Npc.talking = false;
            textfill.dialougeCheck = 10;
            Npc.fadeTransition = true;
            StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
            

        }

        if (Npc2 != null && textfill != null)
        {
            if (Npc2.talking && textfill.dialougeCheck2 == 2)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 1;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));


            }

            if (Npc2.talking && textfill.dialougeCheck2 == 3)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 4;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }

            if (Npc2.talking && textfill.dialougeCheck2 == 5)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 1;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }

            if (Npc2.talking && textfill.dialougeCheck2 == 6)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 7;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }

            if (Npc2.talking && textfill.dialougeCheck2 == 8)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 9;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }

            if (Npc2.talking && textfill.dialougeCheck2 == 9)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 10;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }

            if (Npc2.talking && textfill.dialougeCheck2 == 11)
            {
                Npc2.talking = false;
                textfill.dialougeCheck2 = 10;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }
        }
    }

    public void EndDialougeNpc1()
    {
        Npc.talking = false;
        textfill.dialougeCheck++;
        Npc.fadeTransition = true;
        StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
    }

    public void EndDialougeNpc2()
    {
        Npc2.talking = false;
        textfill.dialougeCheck2++;
        Npc2.fadeTransition = true;
        StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));
    }

    IEnumerator dialogueTransition(NpcBody Npc, Image NpcSprite, GameObject NPCObject)
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
