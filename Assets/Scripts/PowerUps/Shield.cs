using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

        if (player) {
            player.AddShield(1);
            Destroy(gameObject);
        }
    }


}
