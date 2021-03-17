using UnityEngine;

public class FireRateMultiplier : MonoBehaviour
{
    public float multiplier = 2f;   // fire rate multiplier
    public float duration = 10f;    // duration in seconds
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
                powerUpUI.AddFireRateBar(uiBarPrefab, duration);
            }

            weapon.ModifyFireRate(multiplier, duration);
            Destroy(gameObject);
        }
    }
}
