using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TankEnemy : Enemy
{
    [SerializeField]
    private GameObject tankTop; 

    // Update is called once per frame
    void Update()
    {
        Move();

        Vector3 lookPos = transform.position - target.transform.position;
        tankTop.transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
