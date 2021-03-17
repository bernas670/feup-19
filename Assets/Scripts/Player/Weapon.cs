using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject defaultProjectile;
    // number of shots per second
    public float fireRate = 3f;
    // the current projectile the player shoots
    private GameObject currProjectile;
    private IEnumerator activeAmmoRoutine;
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

        if (Input.GetButtonDown("Fire1"))
        {
            if (lastShot >= 1 / fireRate)
            {
                Shoot();
                lastShot = 0;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(currProjectile, firePoint.position, firePoint.rotation);
    }

    public void ModifyFireRate(float multiplier, float duration)
    {
        fireRate *= multiplier;

        StartCoroutine(ResetFireRate(multiplier, duration));
    }

    private IEnumerator ResetFireRate(float multiplier, float duration)
    {
        yield return new WaitForSeconds(duration);
        fireRate /= multiplier;
    }

    public void ChangeAmmo(GameObject projectilePrefab, float duration)
    {
        currProjectile = projectilePrefab;

        if(activeAmmoRoutine != null) {
            StopCoroutine(activeAmmoRoutine);
        }

        activeAmmoRoutine = ResetAmmo(duration);
        StartCoroutine(activeAmmoRoutine);
    }

    private IEnumerator ResetAmmo(float duration)
    {
        yield return new WaitForSeconds(duration);
        currProjectile = defaultProjectile;
    }
}
