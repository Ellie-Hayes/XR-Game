using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private int damage; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void SetDamage(int passedDamage)
    {
        damage = passedDamage;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Health>())
            {
                collision.gameObject.GetComponent<Health>().ApplyDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
