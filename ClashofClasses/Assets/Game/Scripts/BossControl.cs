using System.Collections;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public AudioSource MainTheme;
    public AudioSource FightTheme;
    public OutDoorTalking outDoorTalking;
    private bool fireOnce = true;
    public GameObject Avold;
    public GameObject bossProjectile;
    public Transform firePoint;
    public float speed = 20f;
    private Vector3 direction;
    public GameObject player;
    public enum NPCState
    {
        Idle, Attacking
    }
    public NPCState currentState;
    public float idleTime = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                
            }
            StartCoroutine(StateLoop());

            switch (currentState)
            {
                case NPCState.Idle:
                    Idle();
                    break;

                case NPCState.Attacking:
                    Attacking();
                    break;

                CheckTransitions();
            }
    }

        void Idle()
        {
            //Stands Still
        }

        void Attacking()
        {
            
        }
        void CheckTransitions()
        {
           /* if (distance <= attackRange)
            {
                currentState = NPCState.Attacking;
            }
            else if (distance <= chaseRange)
            {
                currentState = NPCState.Chase;
            }
            else
            {
                currentState = NPCState.Patrol;
            }*/
        }

        IEnumerator StateLoop()
        {
            while (true)
            {
           
                currentState = NPCState.Idle;
                Debug.Log("Idle");

                yield return new WaitForSeconds(idleTime);

            
                currentState = NPCState.Attacking;
                Debug.Log("Attack");

                yield return StartCoroutine(AttackRoutine());
            }
        }

        IEnumerator AttackRoutine()
        {

            GameObject projectile = Instantiate(bossProjectile, firePoint.position, firePoint.rotation);
            FireProjectile script = projectile.GetComponent<FireProjectile>();
            script.SetDirectionForBoss(player.transform.position);

            transform.position += direction * speed * Time.deltaTime;
            yield return null;
           
        }



    }
}
