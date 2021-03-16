using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    public int xOffset = 65;
    public int yOffset = -48;
    public GameObject prefab;
    private GameObject[] activePowerUps;
    private int currentIndex;

    private void Awake()
    {
        activePowerUps = new GameObject[4];
        currentIndex = 0;
    }

    public void AddVaccineBar(float duration)
    {
        //FIXME: maybe a better way to find the VaccinneBar in the array?
        GameObject bar = Array.Find(activePowerUps, power => power != null && power.name == "VaccineBar");

        if (bar == null)
        {
            bar = Instantiate(prefab, new Vector3(xOffset, currentIndex * yOffset, 0), Quaternion.identity);
            bar.transform.SetParent(transform, false);
            activePowerUps[currentIndex] = bar;
        }

        StartCoroutine(AnimateSlider(bar, duration));
    }

    private void SetSliderValue(GameObject bar, float value)
    {
        Slider slider = bar.GetComponentInChildren<Slider>();
        slider.value = value;
    }

    private IEnumerator AnimateSlider(GameObject bar, float duration)
    {
        float progress = 1.0f;
        Slider slider = bar.GetComponentInChildren<Slider>();

        while (progress > 0)
        {
            slider.value = progress;
            progress -= Time.deltaTime / duration;

            yield return null;
        }

        Destroy(bar);
    }
}
