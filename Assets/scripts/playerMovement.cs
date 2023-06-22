using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class playerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 15f; //altura do pulo
    private bool isFacingRight = false;

 
    private int jumpCount = 0;
    private int maxJump = 1;
    private float doubleJumpingPower = 20f;

 
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

    //base do jogo
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

 
    //void de pulo
    void Jump()
    {
        if (isGrounded() || jumpCount < maxJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpCount < maxJump ? doubleJumpingPower : jumpingPower);
            jumpCount++;
            //doubleJump = true;
        }
    }

 
    void Update()
    {
        if(isDashing)
        {
            return;
        }

 

        horizontal = Input.GetAxisRaw("Horizontal");

 

        if (isGrounded())
        {
            jumpCount = 0;
        }

 
        //setando que o botão de pular será espaço
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("doubleJump: " + doubleJump);
            Jump();
        }

 
        //velocidade de pulo
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

 

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

 

        FLip();
    }

 

}