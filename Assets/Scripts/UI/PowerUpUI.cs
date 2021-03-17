using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    public int xOffset = 65;
    public int yOffset = 48;
    private List<GameObject> activePowerUps;

    private void Awake()
    {
        activePowerUps = new List<GameObject>();
    }

    public void AddVaccineBar(GameObject barPrefab, float duration)
    {
        GameObject bar = activePowerUps.Find(power => power.name == "VaccineBar(Clone)");

        if (bar)
        {
            SetBarValue(bar, 1.0f);
            return;
        }

        InstantiateBar(barPrefab, duration);
    }

    public void AddFireRateBar(GameObject barPrefab, float duration)
    {
        InstantiateBar(barPrefab, duration);
    }

    private void InstantiateBar(GameObject bar, float duration)
    {
        bar = Instantiate(bar, new Vector3(xOffset, activePowerUps.Count * -yOffset, 0), Quaternion.identity);
        bar.transform.SetParent(transform, false);
        activePowerUps.Add(bar);
        StartCoroutine(AnimateSlider(bar, duration));
    }

    private void SetBarValue(GameObject bar, float value)
    {
        Slider slider = bar.GetComponentInChildren<Slider>();
        slider.value = value;
    }

    private void RemoveBar(GameObject bar)
    {
        activePowerUps.Remove(bar);
        activePowerUps.ForEach(activeBar => {
            if(activeBar.transform.localPosition.y < 0)
                activeBar.transform.localPosition += Vector3.up * yOffset;
        });
    }

    private IEnumerator AnimateSlider(GameObject bar, float duration)
    {
        Slider slider = bar.GetComponentInChildren<Slider>();
        slider.value = 1.0f;

        while (slider.value > 0)
        {
            slider.value -= Time.deltaTime / duration;

            yield return null;
        }

        RemoveBar(bar);
        Destroy(bar);
    }
}
