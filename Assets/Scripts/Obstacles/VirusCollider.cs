using UnityEngine;

public class VirusCollider : MonoBehaviour
{

    private Virus parentScript;

    private void Awake() {
        parentScript = GetComponentInParent<Virus>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        parentScript.OnTriggerEnter2DChild(other);
    }
}
