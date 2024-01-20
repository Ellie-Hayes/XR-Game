using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    UIManager managerUI; 
    // Start is called before the first frame update
    void Start()
    {
        managerUI = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Pickup pickupScript = other.GetComponent<Pickup>();
            int scorePoints = pickupScript.GetPickedUp();
            managerUI.AddScore(scorePoints);
        }
    }
}
