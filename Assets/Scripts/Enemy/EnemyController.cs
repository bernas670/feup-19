using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameObject player;

    // fire rate in shots per second
    public float fireRate = 3f;
    public GameObject projectile;
    private float lastShot;

    private Renderer rndr;

    void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rndr = GetComponent<Renderer>();

        lastShot = 1 / fireRate;
    }

    void FixedUpdate()
    {
        if (rndr.isVisible)
        {
            if (lastShot >= 1 / fireRate)
            {
                Shoot();
                lastShot = 0f;
            }

            lastShot += Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);

        PlayerScore score = player.GetComponent<PlayerScore>();
        score.UpdateScore(100);
    }

    void Shoot()
    {
        Vector3 playerDir = (player.transform.position - transform.position).normalized;
        float ang = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, ang);

        GameObject projectileInst = Instantiate(projectile, transform.position, rotation);
        projectileInst.transform.SetParent(transform.parent);
    }
}
