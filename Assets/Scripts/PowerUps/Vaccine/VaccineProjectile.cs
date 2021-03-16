using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineProjectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyController enemy = hitInfo.GetComponent<EnemyController>();

        if (enemy)
        {
            enemy.TakeDamage();
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
