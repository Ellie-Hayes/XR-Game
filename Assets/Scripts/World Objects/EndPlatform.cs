using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject completeCanvas;
    Scenes sceneManager; 

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sceneManager = FindObjectOfType<Scenes>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.CurrentPickups >= gameManager.TotalPickups)
            {
               completeCanvas.SetActive(true);
                StartCoroutine("StartMenuSwitch");
            }
        }
    }

    IEnumerator StartMenuSwitch()
    {
        yield return new WaitForSeconds(3f);
        sceneManager.OpenMenu();
    }

}
