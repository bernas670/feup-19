using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    // duration of the power up in seconds
    public float duration = 8f;
    public GameObject projectilePrefab;

    private PowerUpUI powerUpUI;

    private void Awake()
    {
        powerUpUI = GameObject.Find("PowerUps").GetComponent<PowerUpUI>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapon weapon = hitInfo.GetComponent<Weapon>();

        if (weapon)
        {
            if (powerUpUI)
            {
                powerUpUI.AddVaccineBar(duration);
            }

            weapon.ChangeAmmo(projectilePrefab, duration);
            Destroy(gameObject);
        }
    }
}
