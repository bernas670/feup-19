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
    private bool invicible = false;

    public int invicibilityDelay = 2; //in s
    public HealthBar healthBar;
    private Animator animator;

    private void Start()
    {
        healthBar.InitBar(MAX_HEALTH, MAX_SHIELD);
        animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        if (invicible) return;

        EnableInvincibility();

        if (shield > 0)
        {
            DamageShield();
            return;
        }

        DamageHealth();
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

    private void DamageShield()
    {
        shield--;
        healthBar.RemoveShield(shield);

        if (shield <= 0)
        {
            animator.SetBool("hasShield", false);
        }
    }
    
    private void DamageHealth()
    {
        health--;
        healthBar.RemoveHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void EnableInvincibility()
    {
        invicible = true;
        animator.SetBool("isInvincible", true);
        // Will disable the invicibility after "invicibilityDelay" seconds
        StartCoroutine(DisableInvincibility());
    }

    private IEnumerator DisableInvincibility()
    {
        yield return new WaitForSeconds(invicibilityDelay);
        invicible = false;
        animator.SetBool("isInvincible", false);
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        FindObjectOfType<GameManager>().GameOver();

        Debug.Log("DEAD");
    }
}
