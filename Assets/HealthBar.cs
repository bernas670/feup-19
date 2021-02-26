using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject icon;
    public Sprite fullHeart, emptyHeart;
    public Sprite fullShield, emptyShield;

    private int maxHealth, maxShield;
    private GameObject[] bar;

    public void InitBar(int maxHealth, int maxShield)
    {
        this.maxHealth = maxHealth;
        this.maxShield = maxShield;

        bar = new GameObject[maxHealth + maxShield];

        Vector3 offset = new Vector3(75, 0, 0);

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = CreateIcon(offset * i, emptyHeart);
            bar.SetValue(newIcon, i);
        }

        for (int i = 0; i < maxShield; i++)
        {
            GameObject newIcon = CreateIcon(offset * (i + maxHealth), emptyShield);
            bar.SetValue(newIcon, i + maxHealth);
        }
    }

    private GameObject CreateIcon(Vector3 offset, Sprite sprite) {
        GameObject icon = Instantiate(this.icon, this.icon.transform.position + offset, Quaternion.identity);
        icon.transform.SetParent(transform, false);
        icon.GetComponent<Image>().sprite = sprite;
        return icon;
    }

    public void UpdateBar(int health, int shield)
    {
        for (int i = 0; i < maxHealth; i++) {
            if (i < health) {
                bar[i].GetComponent<Image>().sprite = fullHeart;
            } else {
                bar[i].GetComponent<Image>().sprite = emptyHeart;
            }
        }

        for (int i = maxHealth; i < maxHealth + maxShield; i++) {
            if (i < shield) {
                bar[i].GetComponent<Image>().sprite = fullShield;
            } else {
                bar[i].GetComponent<Image>().sprite = emptyShield;
            }
        }
    }   
}
