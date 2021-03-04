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
    public Animator animator;

    public float jumpForce = 5f;

    private bool crouching = false;
    private bool wantToStandUp = false;

    void Awake()
    {
        runColl.enabled = true;
        crouchColl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Crouch();
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            wantToStandUp = true;
        }

        if(wantToStandUp && CanStandUp()) {
            Uncrouch();
            wantToStandUp = false;
        }
    }


    private void Crouch()
    {
        if (crouching)
        {
            return;
        }

        crouching = true;
        animator.SetBool("isCrouching", true);
        firePoint.position = new Vector3(firePoint.position.x + 0.052f, firePoint.position.y - 0.026f, firePoint.position.z);

        runColl.enabled = false;
        crouchColl.enabled = true;
    }

    private void Uncrouch()
    {
        if (!crouching)
        {
            return;
        }

        crouching = false;
        animator.SetBool("isCrouching", false);
        firePoint.position = new Vector3(firePoint.position.x - 0.052f, firePoint.position.y + 0.026f, firePoint.position.z);

        runColl.enabled = true;
        crouchColl.enabled = false;
    }


    private void Jump()
    {
        if (!IsOnGround())
        {
            return;
        }

        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private bool IsOnGround()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

    private bool CanStandUp()
    {
        Collider2D ceilingCheck = Physics2D.OverlapCircle(head.position, 0.1f, groundLayer);

        if (ceilingCheck != null)
        {
            return false;
        }

        return true;
    }
}
