using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public Rigidbody2D rb;
    

    public float speed = 20f;


    void Start()
    {
        rb.velocity = transform.right * speed;        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("Enemy")) {
            return;
        }
        
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player) {
            player.TakeDamage();
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
