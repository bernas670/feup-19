using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{

    // duration of the power up in seconds
    public float duration = 30f;
    public GameObject projectilePrefab;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Weapon weapon = hitInfo.GetComponent<Weapon>();

        if (weapon) {
            weapon.ChangeAmmo(projectilePrefab, duration);
            Destroy(gameObject);
        }
    }
}
