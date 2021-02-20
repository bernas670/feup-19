using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform feet;
    public LayerMask groundLayer;


    public float jumpForce = 5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {

    }


    private void Jump()
    {
        if (IsOnGround())
        {
            // Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            // rb.velocity = movement;

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

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