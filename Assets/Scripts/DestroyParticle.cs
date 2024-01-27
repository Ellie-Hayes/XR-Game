using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    [SerializeField] float timeTillDestroy; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", timeTillDestroy);
    }
    
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
