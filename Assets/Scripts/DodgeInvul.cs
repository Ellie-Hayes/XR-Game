using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeInvul : MonoBehaviour
{
    private Health health;
    private Rigidbody rb;

    private Animator anim;

    [SerializeField] float invulnerableDuration;

    [SerializeField] float dodgeCooldown = 1;
    private float cooldownRemaining;

    [SerializeField] float dodgeForce;
    

    [SerializeField] float dodgeTime;
    private float dodgeTimeRemaining;

    public bool Dodging
    {
        get => dodgeTimeRemaining >= 0 ? true : false;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        bool shouldRoll = Input.GetMouseButton(1);

        //Dodge Cooldown
        if (cooldownRemaining <= 0)
        {
            anim.ResetTrigger("Roll");
            if (shouldRoll) { Dodge(); }
        }
        else { cooldownRemaining -= Time.deltaTime; }

        //Dodge Force
        if (dodgeTimeRemaining > 0)
        {
            rb.AddForce(transform.forward * dodgeForce);
            dodgeTimeRemaining -= Time.deltaTime;
        }
       
    }

    void Dodge()
    {
        cooldownRemaining = dodgeCooldown;
        health.SetInvulnerability(invulnerableDuration);

        dodgeTimeRemaining = dodgeTime;
        anim.SetTrigger("Roll");
    }
}
