using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]

    [SerializeField]
    TextMeshProUGUI scoreText;
    int score = 0;

    //[Header("Health UI")]
    //TODO: Heath bar

    // Start is called before the first frame update
    void Start()
    {
        Health PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        PlayerHealth.OnHealthChanged += UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void UpdateHealth(int currentHealth, int MaxHealth)
    {
        Debug.Log("Health Health"); 
    }
}
