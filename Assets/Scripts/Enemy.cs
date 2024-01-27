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
    protected AudioSource source;

    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    protected bool isDead;


    [SerializeField] protected GameObject attackPoint;
    [SerializeField] protected GameObject attackObject;

    [SerializeField]
    protected float attackTimerDelay = 2f;
    protected float currentAttackTimer;

    protected bool playerInRange;
    [SerializeField] protected float fovRadius = 5f;
    [SerializeField] protected LayerMask playerLayer;

    [SerializeField] int scoreVal;
    


    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();

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
        StartCoroutine("StartAttack");
    }

    protected virtual void EnemyDeath()
    {
        isDead = true; 

        if (anim != null) { anim.SetTrigger("Dead"); }
        else { DestroyEnemy(); }
    }

    public virtual void DestroyEnemy()
    {
        UIManager uimanager = FindObjectOfType<UIManager>();
        uimanager.AddScore(scoreVal);
        Destroy(gameObject);
    }

    protected virtual IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(1f);

        GameObject spawnedAttack = Instantiate(attackObject, attackPoint.transform.position,
          Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up));

        Projectile projectileScript = spawnedAttack.GetComponent<Projectile>();
        if (projectileScript != null) { projectileScript.SetDamage(damage); }

    }
}
