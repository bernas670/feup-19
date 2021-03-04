using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform feet;
    public Transform head;
    public Transform firePoint;
    public LayerMask groundLayer;


    public BoxCollider2D runColl, crouchColl;
    public float jumpForce = 5f;

    private Animator animator;
    private MovementState state;
    private Vector3 firePointOffset = new Vector3(0.052f, -0.026f, 0);

    void Awake()
    {
        runColl.enabled = true;
        crouchColl.enabled = false;
        animator = GetComponent<Animator>();
        state = new Running(this);
    }

    // Update is called once per frame
    void Update()
    {
        state.update();
    }

    public void Jump()
    {
        state = new Jumping(this);
        animator.SetBool("isJumping", true);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void Fall()
    {
        state = new Falling(this);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", true);
    }

    public void Land()
    {
        state = new Running(this);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
    }

    public void Crouch()
    {
        state = new Crouching(this);
        animator.SetBool("isCrouching", true);
        firePoint.position += firePointOffset;

        runColl.enabled = false;
        crouchColl.enabled = true;
    }

    public void Uncrouch()
    {
        state = new Uncrouching(this);
    }

    public void StandUp()
    {
        state = new Running(this);
        animator.SetBool("isCrouching", false);
        firePoint.position -= firePointOffset;

        runColl.enabled = true;
        crouchColl.enabled = false;
    }

    public bool IsFalling()
    {
        return rb.velocity.y < 0;
    }

    public bool IsOnGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);

        if (groundCheck != null)
            return true;

        return false;
    }

    public bool CanStandUp()
    {
        Collider2D ceilingCheck = Physics2D.OverlapCircle(head.position, 0.1f, groundLayer);

        if (ceilingCheck != null)
            return false;

        return true;
    }
}
