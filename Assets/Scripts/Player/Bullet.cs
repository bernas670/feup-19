using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactAnimation;

    // Start is called before the first frame update
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

        CreateImpactEffect();

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void CreateImpactEffect()
    {
        GameObject impactObject = Instantiate(impactAnimation, transform.position, transform.rotation);
        LevelGenerator level = GameObject.Find("Level").GetComponent<LevelGenerator>();
        impactObject.transform.SetParent(level.GetStage(1));
        Destroy(impactObject, 0.4f);
    }
}
