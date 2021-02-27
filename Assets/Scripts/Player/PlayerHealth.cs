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

    private void Start()
    {
        healthBar.InitBar(MAX_HEALTH, MAX_SHIELD);
        healthBar.UpdateBar(health, shield);
    }

    public void TakeDamage()
    {
        if (shield > 0)
        {
            shield--;
        }
        else
        {
            health--;
        }

        healthBar.UpdateBar(health, shield);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("DEAD");
    }

    public void AddShield(int amount)
    {
        if (shield + amount > MAX_SHIELD)
        {
            shield = MAX_SHIELD;
        }
        else
        {
            shield += amount;
        }
        healthBar.UpdateBar(health, shield);
    }
}
