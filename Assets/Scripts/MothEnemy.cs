using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothEnemy : Enemy
{
   
    void Update()
    {
        if (playerInRange) { Move(player.transform.position); }

        currentAttackTimer -= Time.deltaTime;
        if (currentAttackTimer <= 0)
        {
            Attack();
            currentAttackTimer = attackTimerDelay;
        }
    }

   
}
