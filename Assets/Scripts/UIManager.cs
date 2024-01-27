using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]

    [SerializeField]
    TextMeshProUGUI scoreText;
    int score = 0;

    [Header("Health UI")]
    HealthBar healthBar; 

    // Start is called before the first frame update
    void Start()
    {
        Health PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        PlayerHealth.OnHealthChanged += UpdateHealth;

       
        healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxHealth(PlayerHealth.MaxHealth);
    }
   
    public void AddScore(int scoreVal)
    {
        score += scoreVal;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateHealth(int MaxHealth, int currentHealth)
    {
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

  
   
}
