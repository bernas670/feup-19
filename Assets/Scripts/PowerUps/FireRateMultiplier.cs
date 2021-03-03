using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateMultiplier : MonoBehaviour
{
    public float multiplier = 2f;   // fire rate multiplier
    public float duration = 10f;    // duration in seconds

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapon weapon = hitInfo.GetComponent<Weapon>();

        if (weapon)
        {
            weapon.ModifyFireRate(multiplier, duration);
            Destroy(gameObject);
        }
    }
}
