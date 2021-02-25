﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform feet;
    public LayerMask groundLayer;


    public BoxCollider2D runColl, crouchColl;


    public float jumpForce = 5f;


    private bool crouching = false;

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
            Uncrouch();
        }

    }


    private void Crouch()
    {
        if (crouching)
        {
            return;
        }

        crouching = true;

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
}
