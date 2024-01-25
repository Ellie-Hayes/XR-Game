using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Health health;
    protected NavMeshAgent agent;
    protected GameObject player;

    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    protected bool isDead;


    [SerializeField]
    protected GameObject attackPoint;
    [SerializeField]
    protected GameObject attackObject;

    [SerializeField]
    protected float attackTimerDelay = 2f;
    protected float currentAttackTimer;

    protected bool playerInRange;
    [SerializeField]
    protected float fovRadius = 2f;
    [SerializeField]
    protected LayerMask playerLayer; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();

        if (health != null) { health.OnHealthDepleted += EnemyDeath; }

        player = GameObject.FindGameObjectWithTag("Player");
        currentAttackTimer = attackTimerDelay;
    }

    private void Update()
    {
        Move(player.transform.position);
    }

    protected void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, fovRadius, playerLayer);
        if (colliders.Length > 0) { playerInRange = true; }
        else { playerInRange = false; }
    }

    protected virtual void Move(Vector3 moveToPosition)
    {
        agent.destination = moveToPosition;
        agent.speed = speed;
    }

    protected virtual void Attack()
    {
        GameObject spawnedAttack = Instantiate(attackObject, attackPoint.transform.position,
           Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up));

        Projectile projectileScript = spawnedAttack.GetComponent<Projectile>();
        if (projectileScript != null) { projectileScript.SetDamage(damage); }
    }

    protected virtual void EnemyDeath()
    {
        isDead = true; 

        if (anim != null) { anim.SetTrigger("Dead"); }
        else { DestroyEnemy(); }
    }

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
