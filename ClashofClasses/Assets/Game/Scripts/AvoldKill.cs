using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class AvoldKill : MonoBehaviour
{
    public OutDoorTalking outDoorTalking;
    public Slider healthBar;
    public TextMeshProUGUI badEnd;
    public TextMeshProUGUI badEndHint;
    public Slider staminaBar;
    public Image swordStab;
    public Image blood;
    public NpcBody npc;
    public Fade fade;
    public PlayerCamera playerCamera;
    public AudioSource stab;
    public bool forceKill = false;
    public bool fireOnce = true;
    public StabBox stabBox;
    public Camera cam;
    private Renderer render;
    public bool instantDeath = false;
    public Image bloodSplat;
    public Image sword;
    public Vector3 swordTarget = new Vector3(7.064017f, -146.8228f, 144.8126f);
    public float moveSpeed = 100f;
    RectTransform rt;
    public AudioSource bodyDrop;
    public Image endScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = GetComponent<Renderer>();
        badEnd.enabled = false;
        badEndHint.enabled = false;
        bloodSplat.enabled = false;
        rt = sword.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (!GeometryUtility.TestPlanesAABB(planes, render.bounds))
        {

            if (outDoorTalking.readyToKill && stabBox.playerInside == true || forceKill && stabBox.playerInside == true)
            {
                if (fireOnce)
                {
                    instantDeath = true;
                    outDoorTalking.noInputs = true;
                    playerCamera.canMoveCamera = false;
                    stab.Play();
                    bloodSplat.enabled = true;
                    StartCoroutine(DeathSequence());
                    fireOnce = false;
                }

                Vector2 target = new Vector2(7.06f, -146.82f);
                rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, target, moveSpeed * Time.deltaTime);

            }
            }
        }

    IEnumerator DeathSequence()
    {
       
        yield return new WaitForSeconds(4f);
        bodyDrop.Play();
        StartCoroutine(fade.FadeInOut());
        yield return new WaitForSeconds(1f);
        endScreen.enabled = true;
        healthBar.gameObject.SetActive(false);
        staminaBar.gameObject.SetActive(false);
        swordStab.enabled = false;
        blood.enabled = false;
        badEnd.enabled = true;
        badEndHint.enabled = true;



    }
    }


