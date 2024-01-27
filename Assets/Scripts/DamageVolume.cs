using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVolume : MonoBehaviour
{
    [SerializeField] string TagToDamage;
    [SerializeField] int damage;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagToDamage)) 
        {
            Debug.Log("Ouch");

            if (other.GetComponent<Health>())
            {
                other.GetComponent<Health>().ApplyDamage(damage);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagToDamage))
        {
            Debug.Log("Ouch");

            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().ApplyDamage(damage);
            }
        }
    }
}
