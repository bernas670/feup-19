using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private const int MAX_HEALTH = 3;
    private const int MAX_SHIELD = 2;

    private int health = MAX_HEALTH;
    private int shield = 0;

    public HealthBar healthBar;
    private Animator animator;

    private void Start()
    {
        healthBar.InitBar(MAX_HEALTH, MAX_SHIELD);
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        if (shield > 0)
        {
            shield--;
            healthBar.RemoveShield(shield);

            if (shield <= 0)
            {
                animator.SetBool("hasShield", false);
            }
        }
        else
        {
            health--;
            healthBar.RemoveHealth(health);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void AddShield()
    {
        animator.SetBool("hasShield", true);

        if (shield < MAX_SHIELD)
        {
            shield++;
            healthBar.AddShield(shield - 1);
        }
    }

    private void Die()
    {
        Debug.Log("DEAD");
    }
}
