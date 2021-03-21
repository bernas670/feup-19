using UnityEngine;

public class Virus : MonoBehaviour
{
    public float speed = 10f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    public void OnTriggerEnter2DChild(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player)
        {
            player.TakeDamage();
        }

        VaccineProjectile vaccine = other.GetComponent<VaccineProjectile>();
        if (vaccine)
        {
            PlayerScore score = this.player.GetComponent<PlayerScore>();
            score.UpdateScore(200);

            Destroy(gameObject);
        }

    }
}
