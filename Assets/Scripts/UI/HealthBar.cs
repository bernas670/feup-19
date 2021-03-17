using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int offset = 40;
    public GameObject iconPrefab;
    public Sprite fullHeart, emptyHeart, fullShield;

    private int maxHealth, maxShield;
    private GameObject[] bar;

    public void InitBar(int maxHealth, int maxShield)
    {
        this.maxHealth = maxHealth;
        this.maxShield = maxShield;

        bar = new GameObject[maxHealth + maxShield];

        Vector3 offsetVector = new Vector3(offset, 0, 0);

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = CreateIcon(offsetVector * i, fullHeart);
            bar.SetValue(newIcon, i);
        }
    }

    public void RemoveHealth(int index)
    {
        if (index < 0 || index >= bar.Length)
            return;

        bar[index].GetComponent<Image>().sprite = emptyHeart;
    }

    public void AddShield(int index)
    {
        int shieldIndex = index + maxHealth;
        if (shieldIndex < 0 || shieldIndex >= bar.Length)
            return;

        bar.SetValue(CreateIcon(new Vector3(offset, 0, 0) * shieldIndex, fullShield), shieldIndex);
    }

    public void RemoveShield(int index)
    {
        if (index < 0 || index >= bar.Length)
            return;

        Destroy(bar[index + maxHealth]);
    }

    private GameObject CreateIcon(Vector3 offset, Sprite sprite)
    {
        GameObject icon = Instantiate(iconPrefab, iconPrefab.transform.position + offset, Quaternion.identity);
        icon.transform.SetParent(transform, false);
        icon.GetComponent<Image>().sprite = sprite;
        return icon;
    }
}
