using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool pressVerticalInput;
    private bool freeVerticalInput;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = false;
 
    private int jumpCount = 0;
    private int maxJump = 1;
 
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 54f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower * -1, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FLip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
 
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    void Jump()
    {
        if (isGrounded() || jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpCount++;
        }
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        pressVerticalInput = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        freeVerticalInput = Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow);

        if (isGrounded())
        {
            jumpCount = 0;
        }
 
        if (pressVerticalInput)
        {
            Jump();
        }
 
        if (freeVerticalInput && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        FLip();
    }
}