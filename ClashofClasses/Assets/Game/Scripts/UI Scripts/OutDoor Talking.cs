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
    public NpcBody Npc3;
    public PlayerMovement player;
    [SerializeField] private UiElements uiElements;
    public Image NpcSprite;
    public Image Npc2Sprite;
    public Image Npc3Sprite;
    public Fade fade;
    public GameObject NPCObject;
    public GameObject NPC2Object;
    public GameObject NPC3Object;
    public Image sword1;
    public Image sword2;
    public Image sword3;
    public Image textBox;
    public AudioSource heal;
    public TextMeshProUGUI textMeshPro;
    private int selectedSword;
    public PlayerCamera playerCamera;
    public float fadeTime = 3f;
    public bool isDialogue = false;
    public Slider healthBar;
    public Slider staminaBar;
    public Camera playerCam;
    public TextFill textfill;
    public bool readyToKill = false;
    public bool bossStart = false;
    private Vector3 avoldHouse= new Vector3(13.17f, 1.287f, 40.79f);
    private int readyToKillChecker = 10;
    private int bossStartChecker = 14;

    private int[] NPC1Flags = {3, 5, 7, 10, 14, 100};
    private int[] NPC1HoldFlags = { 7, 10, 14, 100 };
    public int NPC1FlagsIndex = 0;
    public int NPC1HoldFlagsIndex = 0;
    public int[] NPC1Teleports = {1, 100};
    public int NPC1TeleportsIndex = 0;

    public int[] NPC2Flags = {1, 2};
    public int[] NPC2HoldFlags = {1};
    public int NPC2FlagsIndex = 0;
    public int NPC2HoldFlagsIndex = 0;
    public int NPC2HealIndex = 1;
    public int[] NPC2Teleports = {100};
    public int NPC2TeleportsIndex = 0;

    private int NPC3Flag = 5;
    private int NPC3Reset = 0;
    private bool healOnce = true;



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

        if (Npc3Sprite != null)
        {
            Npc3Sprite.enabled = false;
        }

        if (Npc2Sprite != null)
        {
            Npc2Sprite.enabled = false;
        }

        if (NpcSprite != null)
        {
            NpcSprite.enabled = false;
        }

     

    }

    // Update is called once per frame
    void Update()
    {
        if (textfill.dialougeCheck == NPC1Teleports[NPC1TeleportsIndex])
        {
            NPCTeleport(NPCObject, avoldHouse);
        }

        if (Npc2 != null)
        {
            if (!Npc2.talking)
            {
                healOnce = true;
            }
        }

        if (Npc2 != null)
        {
            if (textfill.dialougeCheck2 == NPC2HealIndex && Npc2.talking)
            {
                if (healOnce)
                {
                    uiElements.currentHealth = 100;
                    heal.Play();
                    healOnce = false;
                }
            }
        }

        if (Npc != null) {
            if (Npc.talking)
            {
                readyToKill = false;
            }
        }

        if (bossStartChecker == textfill.dialougeCheck && !Npc.talking)
        {
            bossStart = true;
        }

        if (readyToKillChecker == textfill.dialougeCheck && !textfill.goodEnd)
        {
            readyToKill = true;
        }

        if (Npc != null)
        {
            if (Npc.talking)
            {

                StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
                noInputs = true;

            }
        }

        if (Npc2 != null)
        {
            if (Npc2.talking)
            {
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));
                noInputs = true;

            }
        }

        if (Npc3 != null)
        {
            if (Npc3 != null && Npc3.talking)
            {
                StartCoroutine(dialogueTransition(Npc3, Npc3Sprite, NPC3Object));
                noInputs = true;

            }
        }

        if (Npc != null)
        {
            if (Npc.talking && textfill.dialougeCheck == NPC1HoldFlags[NPC1HoldFlagsIndex])
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    Npc.talking = false;
                    Npc.fadeTransition = true;
                    StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));
                }
            }


            else if (Npc.talking && textfill.dialougeCheck == NPC1Flags[NPC1FlagsIndex])
            {
                Npc.talking = false;
                NPC1FlagsIndex++;
                Npc.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc, NpcSprite, NPCObject));

            }
        }

        if (Npc2 != null)
        {
            if (Npc2.talking && textfill.dialougeCheck2 == NPC2HoldFlags[NPC2HoldFlagsIndex] || Npc2.talking && !textfill.finalState)
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    Npc2.talking = false; 
                    Npc2.fadeTransition = true;
                    StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));
                }
            }


            else if (Npc2.talking && textfill.dialougeCheck2 == NPC2Flags[NPC2FlagsIndex])
            {
                Npc2.talking = false;
                NPC2FlagsIndex++;
                Npc2.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc2, Npc2Sprite, NPC2Object));

            }
        }

        if (Npc3 != null)
        {
           
           if (Npc3.talking && textfill.dialougeCheck3 == NPC3Flag)
            {
                Npc3.talking = false;
                textfill.dialougeCheck3 = NPC3Reset;
                Npc3.fadeTransition = true;
                StartCoroutine(dialogueTransition(Npc3, Npc3Sprite, NPC3Object));

            }
        } 
    }

    public void NPCTeleport(GameObject NPC, Vector3 position)
    {
        NPC.transform.localPosition = position;
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
