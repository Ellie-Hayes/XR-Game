using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TankEnemy : Enemy
{
    [SerializeField]
    private GameObject tankTop;

    
    // Update is called once per frame
    void Update()
    {
        if (playerInRange) { Move(player.transform.position); }
       

        Vector3 lookPos = transform.position - player.transform.position;
        tankTop.transform.rotation = Quaternion.LookRotation(lookPos);

        currentAttackTimer -= Time.deltaTime;
        if (currentAttackTimer <= 0)
        {
            Attack();
            currentAttackTimer = attackTimerDelay;
        }
    }

     
}
