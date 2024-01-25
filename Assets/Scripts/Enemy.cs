using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Health health;
    protected NavMeshAgent agent;
    protected GameObject target;

    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    protected bool isDead; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();

        if (health != null)
        {
            health.OnHealthDepleted += EnemyDeath; 
        }

        target = GameObject.FindGameObjectWithTag("Player");
         
    }

    private void Update()
    {
        Move();
    }
    protected virtual void Move()
    {
        
        agent.destination = target.transform.position;
        agent.speed = speed;
    }

    protected virtual void Attack()
    {

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
