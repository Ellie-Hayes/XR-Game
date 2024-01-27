using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 1.0f;
    public float JumpForce = 10.0f;
    public float turnSmoothTime; 

    float turnSpeed; 

    Animator anim;
    Rigidbody rb;

    Vector3 moveDirection;

    [SerializeField] GameObject footPos;
    [SerializeField] LayerMask GroundLayer;

    AudioSource source; 
    bool onGround;

    [SerializeField] AudioClip jumpClip; 
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(Horizontal, 0.0f, Vertical);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(new Vector3(0.0f, JumpForce, 0.0f));
            source.PlayOneShot(jumpClip);
        }


        if (moveDirection != Vector3.zero) // Change players rotation and set run animation 
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0.0f);

            anim.SetBool("IsMoving", true);
        }
        else { anim.SetBool("IsMoving", false); }

    }

    private void FixedUpdate()
    {
        float tempVelocity = rb.velocity.y;
        rb.velocity = moveDirection * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(rb.velocity.x, tempVelocity, rb.velocity.z);


        Collider[] colliders = Physics.OverlapSphere(footPos.transform.position, 1, GroundLayer);
        if (colliders.Length > 0) { onGround = true; }
        else { onGround = false; }
    }

   


}
