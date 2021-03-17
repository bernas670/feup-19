using UnityEngine;

public class Stage : MonoBehaviour
{

    public GameObject[] backgrounds;
    private Vector3 offset = new Vector3(6, 0, 0);

    private void Awake() {
        int i = Random.Range(0, backgrounds.Length);

        GameObject background = Instantiate(backgrounds[i], transform.position + offset, Quaternion.identity);
        background.transform.SetParent(transform);
    }
}
