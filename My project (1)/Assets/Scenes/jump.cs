using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField] float jumpTime;
    [SerializeField] int jumpPower;
    [SerializeField] float jumpMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    //bool isGrounded;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;

    bool grounded = true;
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            grounded = false;
        }
        if (rb.velocity.x < 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            //rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }
        if(Input.GetButtonUp("Jump"))
        {
            isJumping = true;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
}