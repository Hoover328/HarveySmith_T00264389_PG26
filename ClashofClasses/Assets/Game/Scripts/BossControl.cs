using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    public AudioSource MainTheme;
    public AudioSource FightTheme;
    public OutDoorTalking outDoorTalking;
    public TextFill textFill;
    private bool fireOnce = true;
    public GameObject Avold;
    public GameObject bossProjectile;
    public GameObject bossProjectileParry;
    public Transform firePoint;
    public float speed = 20f;
    private Vector3 direction;
    public GameObject player;
    public bool fireOnceStates = true;
    public AudioSource fireLaser;
    public AudioSource warningSound;
    public AudioSource parryShot;
    public Image warningImage;
    public GameObject ground;
    public List<GameObject> Spiders = new List<GameObject>();
    public List<GameObject> Canons1 = new List<GameObject>();
    public List<GameObject> Canons2 = new List<GameObject>();
    public enum NPCState
    {
        Idle, Attacking, Counter
    }
    public NPCState currentState;
    public float idleTime = 15f;
    public float attackingTime = 15f;
    public float attackDelay = 2f;

    private bool attackFireOnce = true;
    private bool attackFireOnce2 = true;
    private bool isRunningState = false;
    private bool attackFireOnce3 = true;
    private bool parryAttackonce = true;
    private bool parryAttackonce2 = true;
    private bool dialougeFireOnce = true;
    public float projectileSpeed = 20f;
    private float random = 0.1f;
    private bool fireOnceParry1 = true;
    private bool fireOnceParry2 = false;
    private bool fireOncePitch = true;
    private float parryTimeLimit = 10f;
    [SerializeField] private int counter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        warningImage.enabled = false;
        foreach (GameObject obj in Spiders)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in Canons1)
        {
            obj.SetActive(false);
        }

        foreach(GameObject obj in Canons2)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        if (outDoorTalking.bossStart)
        {
            if (fireOnce)
            {
                MainTheme.Stop();
                FightTheme.Play();
                fireOnce = false;
                Avold.transform.position = new Vector3(16.822f, -73.74677f, 125.529f);
                ChangeState(NPCState.Idle);
                
            }
        

            switch (currentState)
            {
                case NPCState.Idle:
                    Idle();
                    break;

                case NPCState.Attacking:
                    Attacking();
                    break;

                case NPCState.Counter:
                    Counter();
                    break;

            }

            if(counter == 0)
            {
                ground.transform.localPosition = new Vector3(-14.0359f, -19f, 49.81229f);
                ground.transform.localScale = new Vector3(37.26265f, 39.00104f, 28.62039f);
            }

            if (counter == 1)
            {
                foreach (GameObject canons1 in Canons1)
                {
                    canons1.SetActive(true);
                }
            }

            if (counter == 2)
            {
                foreach (GameObject canons2 in Canons2)
                {
                    canons2.SetActive(true);
                }
            }

            if (counter == 3)
            {
                foreach (GameObject spiders in Spiders)
                {
                    spiders.SetActive(true);
                }
            } 
        }
        if (counter == 4)
        {
            outDoorTalking.bossStart = false;
            StopAllCoroutines();
            FightTheme.Stop();
            Avold.transform.position = new Vector3(17.14f, -77.69f, 118.34f);
            foreach (GameObject spiders in Spiders)
            {
                spiders.SetActive(false);
            }
            foreach (GameObject canons2 in Canons2)
            {
                canons2.SetActive(false);
            }
            foreach (GameObject canons1 in Canons1)
            {
                canons1.SetActive(false);
            }

            if (dialougeFireOnce)
            {
                outDoorTalking.NPC1FlagsIndex++;
                outDoorTalking.NPC1HoldFlagsIndex++;
                textFill.dialougeCheck++;
                dialougeFireOnce = false;
            }

        }
    }

    void ChangeState(NPCState newState)
    {
        currentState = newState;

        StopAllCoroutines();

        switch (currentState)
        {
            case NPCState.Idle:
                StartCoroutine(IdleRoutine());
                break;

            case NPCState.Attacking:
                StartCoroutine(AttackRoutine());
                break;

            case NPCState.Counter:
                StartCoroutine(CounterRoutine());
                break;
        }
    }
    void Idle()
    {
        if (!isRunningState)
        {
            StartCoroutine(IdleRoutine());
        }

    }

    void Attacking()
    {

        if (!isRunningState)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    void Counter()
    {
        if (!isRunningState)
        {
            StartCoroutine(CounterRoutine());
        }

    }


    IEnumerator IdleRoutine()
    {
        yield return new WaitForSeconds(idleTime);

        FightTheme.pitch = 1f;
        projectileSpeed = speed;
        attackFireOnce = true;
        attackFireOnce2 = true;
        attackFireOnce3 = true;
        parryAttackonce = true;
        parryAttackonce2 = true;

        ChangeState(NPCState.Attacking);


    }

    IEnumerator AttackRoutine()
    {
        if (attackFireOnce)
        {
            warningSound.Play();
            warningImage.enabled = true;
            attackFireOnce = false;
        }

        yield return new WaitForSeconds(attackDelay);

        if (attackFireOnce2)
        {
            warningImage.enabled = false;
            fireLaser.Play();
            attackFireOnce2 = false;
        }

        GameObject projectile = Instantiate(bossProjectile, firePoint.position, firePoint.rotation);
        FireProjectile script = projectile.GetComponent<FireProjectile>();
        script.SetDirectionForBoss(player.transform.position);

        yield return new WaitForSeconds(attackingTime);

        ChangeState(NPCState.Counter);

    }

    IEnumerator CounterRoutine()
    {
        if (parryAttackonce)
        {
            warningSound.Play();
            warningImage.enabled = true;
            parryAttackonce = false;
        }

        yield return new WaitForSeconds(attackDelay);

        if (parryAttackonce2)
        {
            warningImage.enabled = false;
            parryShot.Play();
            parryAttackonce2 = false;
        }

        if (attackFireOnce3)
        {
            GameObject projectile = Instantiate(bossProjectileParry, firePoint.position, firePoint.rotation);
            FireProjectile script = projectile.GetComponent<FireProjectile>();
            Parry script2 = projectile.GetComponent<Parry>();
            script.SetDirectionForBoss(player.transform.position);
            attackFireOnce3 = false;

            while (projectile != null)
            {

                script.speed = projectileSpeed;


                if (script2.CompareTag("ParryAttack") && fireOnceParry1)
                {
                    fireOnceParry1 = false;
                    script.SetDirectionForBoss(player.transform.position);
                    fireOnceParry2 = true;
                }
                else if (script2.CompareTag("CanHitBoss") && fireOnceParry2)
                {
                    fireOnceParry2 = false;
                    script.SetDirectionForBoss(Avold.transform.position);
                    fireOnceParry1 = true;
                }

                yield return null;
            }
        }

        yield return new WaitForSeconds(parryTimeLimit);
        ChangeState(NPCState.Idle); 

    
}

    void OnTriggerEnter(Collider attack)
    {
        if (attack.CompareTag("CanHitBoss"))
        {
            
            
            if (Random.value >= random)
            {
               
            if (fireOncePitch)
            {
                FightTheme.pitch += 0.05f;
                projectileSpeed += 5f;
                random += 0.1f;
                attack.gameObject.tag = "ParryAttack";
                fireOncePitch = false;
            }

            fireOncePitch = true;
            }

            else
            {
                Destroy(attack.gameObject);
                FightTheme.pitch = 1f;
                projectileSpeed = speed;
                counter++;
            }
        }
    }
}


