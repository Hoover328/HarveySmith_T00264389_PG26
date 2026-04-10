using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class AvoldKill : MonoBehaviour
{
    public OutDoorTalking outDoorTalking;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = GetComponent<Renderer>();
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
                    stab.Play();
                    bloodSplat.enabled = true;
                    fireOnce = false;
                }
                    Vector2 target = new Vector2(7.06f, -146.82f);
                    rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition,target,moveSpeed * Time.deltaTime);
                   
                }
            }
        }
    }


