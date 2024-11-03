using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 4f;
    public float jumpSpeed = 8f;
    public float jumpSpeed2 = 8f;
    private bool isRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool doubleJump;
    private bool firstJump;

    public Animator animator;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            doubleJump = false;
        }

        if (!IsGrounded() && firstJump)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

                firstJump = true;

                doubleJump = true;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed2);

                doubleJump = false;

                firstJump = false;
            }
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isRight && horizontal < 0f || !isRight && horizontal > 0f)
        {
            isRight = !isRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
