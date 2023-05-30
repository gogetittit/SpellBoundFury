using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{//Movement
    [SerializeField] private float moveSpeed;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [SerializeField] private ParticleSystem dust;
    //References
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            if (!dust.isPlaying) // Instantiate dust particles if not already playing
            {
                dust.Play();
            }
        }
        else if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            if (!dust.isPlaying) // Instantiate dust particles if not already playing
            {
                dust.Play();
            }
        }
        else
        {
            dust.Stop(); // Stop dust particles if no movement
        }
    }

    void Move()
    {
       
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
      
    }
}

