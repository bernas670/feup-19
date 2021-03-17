using UnityEngine;

public class Vaccine : MonoBehaviour
{
    public float duration = 8f; // duration of the power up in seconds
    public GameObject projectilePrefab;
    public GameObject uiBarPrefab;

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
                powerUpUI.AddVaccineBar(uiBarPrefab, duration);
            }

            weapon.ChangeAmmo(projectilePrefab, duration);
            Destroy(gameObject);
        }
    }
}
