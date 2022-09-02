using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Animator animController;

    public float lookRadius = 6f;
    public float meleeRange = 1f;

    public float curHP;
    public float maxHP;

    public GameObject Target;
    Transform player;

    public int AttackDamage;
    public float AttackCooldownTimerMain;
    public float AttackCooldownTimer;

    private static int ANIMATOR_PARAM_WALK_SPEED =
        Animator.StringToHash("WalkSpeed");

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animController = GetComponent<Animator>();

        player = GameObject.Find("Body").transform;

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;


        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    public void PatrolWaitTimer()
    {
        //animController.SetBool("IsWalking", false);
        StartCoroutine(PatrolPause(3));
        GotoNextPoint();
    }


    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 1.8f)
        {
            PatrolWaitTimer();

        }
        if (distance <= lookRadius)
        {
            agent.SetDestination(player.position);
        }
        if (distance <= meleeRange)
        {
            animController.SetTrigger("AttackPlayer");
            HitTarget();
        }
    }

    private void LateUpdate()
    {
        float speed = this.agent.velocity.magnitude;
        this.animController.SetFloat(ANIMATOR_PARAM_WALK_SPEED, speed);
    }

    IEnumerator PatrolPause(int waitTime)
    {
        int duration = waitTime;
        agent.Stop();

        while (duration > 0)
        {
            yield return new WaitForSeconds(1);
            duration--;

        }
        agent.Resume();
    }

    void HitTarget()
    {
        if (AttackCooldownTimer > 0)
            AttackCooldownTimer -= Time.deltaTime;
        else
        {
            AttackCooldownTimer = AttackCooldownTimerMain;
            AttackTarget();
        }
    }

    void AttackTarget()
    {
        Target.transform.GetComponent<PlayerMovement>().RecieveDamage(AttackDamage);
        Debug.Log("ouch");
    }

    public void RecieveDamage(float dmg)
    {
        curHP -= dmg;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }
}