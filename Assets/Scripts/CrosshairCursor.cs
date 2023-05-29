using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = ClampToScreen(cursorPosition);
    }

    private Vector2 ClampToScreen(Vector2 position)
    {
        Vector2 clampedPosition = position;
        Vector2 screenMin = Camera.main.ScreenToWorldPoint(Vector2.zero);
        Vector2 screenMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenMin.x, screenMax.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenMin.y, screenMax.y);

        return clampedPosition;
    }
}
