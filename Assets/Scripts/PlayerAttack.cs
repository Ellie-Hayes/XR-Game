using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    GameObject damageCollider;

    [SerializeField]
    private int numberOfAttacks = 3;
    private int currentAttackCounter;

    public int CurrentAttackCounter 
    {
        get => currentAttackCounter;
        private set { currentAttackCounter = value >= numberOfAttacks ? 0 : value; }
    } 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CurrentAttackCounter++;
            Attack();
            Debug.Log(currentAttackCounter);
        }    
    }

    void Attack()
    {
        anim.SetInteger("Counter", currentAttackCounter);
        anim.SetTrigger("Attack");

        StartCoroutine("AttackColl");
    }

    IEnumerator AttackColl()
    {
        damageCollider.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        damageCollider.SetActive(false);
    }
}
