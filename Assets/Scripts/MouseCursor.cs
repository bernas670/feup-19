using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    public void Disable()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    
    public void Enable()
    {
        Cursor.visible = false;
        gameObject.SetActive(true);
    }
}
