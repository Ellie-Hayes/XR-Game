using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    AudioSource source;
    [SerializeField] AudioClip hitClip;

    public Action OnHealthDepleted;
    public Action<int, int> OnHealthChanged;

    [SerializeField]
    int maxHealth;
    int currentHealth;

    private float invulnerableTimer;

    public int MaxHealth { get => maxHealth; }
    public void Start()
    {
        currentHealth = maxHealth;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (invulnerableTimer > 0)
        {
            invulnerableTimer -= Time.deltaTime;
        }
    }

    public void ApplyDamage(int damage)
    {
        if (invulnerableTimer > 0) return; 

        if(source != null) { source.PlayOneShot(hitClip); }

        currentHealth -= damage;
        OnHealthChanged?.Invoke(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            OnHealthDepleted.Invoke();
        }
    }
    public void ApplyHealing(int healing)
    {
        currentHealth += healing;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthChanged?.Invoke(maxHealth, currentHealth);
    }

    public void SetInvulnerability(float invulTime)
    {
        invulnerableTimer = invulTime;
    }
}
