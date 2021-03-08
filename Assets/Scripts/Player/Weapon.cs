using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject defaultProjectile;

    // the current projectile the player shoots
    private GameObject currProjectile;

    // number of shots per second
    public float fireRate = 3f;
    private float lastShot;

    void Awake()
    {
        currProjectile = defaultProjectile;
        lastShot = 1 / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = (mousePos - firePoint.position).normalized;
        float ang = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        firePoint.eulerAngles = new Vector3(0, 0, ang);

        lastShot += Time.deltaTime;


        if (Input.GetButtonDown("Fire1")) {
            if (lastShot >= 1 / fireRate) {
            Shoot();
                lastShot = 0;
            }
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(currProjectile, firePoint.position, firePoint.rotation);
    }

    public void ModifyFireRate(float multiplier, float duration) {
        float originalFireRate = fireRate;
        fireRate *= multiplier;

        StartCoroutine(ResetFireRate(originalFireRate, duration));
    }

    private IEnumerator ResetFireRate(float value, float duration) {
        yield return new WaitForSeconds(duration);
        fireRate = value;
    }

    public void ChangeAmmo(GameObject projectilePrefab, float duration) {
        currProjectile = projectilePrefab;

        StartCoroutine(ResetAmmo(duration));
    }

    private IEnumerator ResetAmmo(float duration) {
        yield return new WaitForSeconds(duration);
        currProjectile = defaultProjectile;
    }

}
