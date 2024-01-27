using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TankEnemy : Enemy
{
    [SerializeField] private GameObject tankTop;

    [SerializeField] private float fleeRange;
    [SerializeField] private GameObject attackCanvas;

    [SerializeField] AudioClip shootClip;
    [SerializeField] GameObject shootParticle;
    

    // Update is called once per frame
    void Update()
    {
        if (playerInRange) 
        {
            if (Vector3.Distance(player.transform.position, transform.position) > fleeRange + 2)
            {
                Move(player.transform.position);
            }
            else if(Vector3.Distance(player.transform.position, transform.position) < fleeRange)
            {
                Vector3 direction = transform.position - player.transform.position;
                Move(direction);
            }
            

            currentAttackTimer -= Time.deltaTime;
            if (currentAttackTimer <= 0)
            {
                Attack();
                currentAttackTimer = attackTimerDelay;
            }
        }
       

        Vector3 lookPos = transform.position - player.transform.position;
        tankTop.transform.rotation = Quaternion.LookRotation(lookPos);
    }

    protected override IEnumerator StartAttack()
    {
        attackCanvas.SetActive(true);

        yield return new WaitForSeconds(1f);

        source.PlayOneShot(shootClip); 
        attackCanvas.SetActive(false);

        Instantiate(shootParticle, attackPoint.transform.position,
          Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up));

        GameObject spawnedAttack = Instantiate(attackObject, attackPoint.transform.position,
          Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up));

        Projectile projectileScript = spawnedAttack.GetComponent<Projectile>();
        if (projectileScript != null) { projectileScript.SetDamage(damage); }

    }


}
