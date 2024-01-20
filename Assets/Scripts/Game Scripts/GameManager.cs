using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int collectedPickups;
    int totalPickups;

    public int CurrentPickups { get { return collectedPickups; } }
    public int TotalPickups { get { return totalPickups; } }

    void Start()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");
        totalPickups = pickups.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectPickup()
    {
        collectedPickups++;
    }
}
