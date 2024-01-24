using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected Health health;

    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int speed;
    protected bool isDead; 

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();

        if (health != null)
        {
            health.OnHealthDepleted += EnemyDeath; 
        }
    }

    protected virtual void Move()
    {

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
