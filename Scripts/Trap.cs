using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int AttackDamage;
    public GameObject Target;
    public float AttackCooldownTimerMain;
    public float AttackCooldownTimer;

    private void Update()
    {
        if (AttackCooldownTimer > 0)
            AttackCooldownTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (AttackCooldownTimer <= 0)
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
}
