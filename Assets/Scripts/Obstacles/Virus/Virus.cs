using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public float speed = 10f;


    public void OnTriggerEnter2DChild(Collider2D other) {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player) {
            player.TakeDamage();
        }
    }
}
