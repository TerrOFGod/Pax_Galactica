using System;
using UnityEngine;

[Serializable]
public class DrawSelectUnits
{
    [SerializeField]
    private float basePointSize;
    [SerializeField]
    private RectTransform squareTexture;

    private Vector2 startPositionMouse;

    public void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartDraw();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Draw();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EndDraw();
        }
    }

    private void StartDraw()
    {
        startPositionMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        SetRect(startPositionMouse, Vector2.one);
        squareTexture.gameObject.SetActive(true);
    }

    private void Draw()
    {
        var rect = GetRect();
        SetRect(rect.position, rect.size);
    }

    public Rect GetRect()
    {
        var endPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var rect = endPosition - startPositionMouse;
        var startPosition = startPositionMouse;

        if (rect.x <= 0)
        {
            rect.x = Mathf.Abs(rect.x);
            startPosition.x -= rect.x;
        }

        if (rect.y <= 0)
        {
            rect.y = Mathf.Abs(rect.y);
            startPosition.y -= rect.y;
        }

        var centerPosition = rect / 2 + startPosition;
        return new Rect(centerPosition, rect.magnitude != 0f ? rect : new Vector2(basePointSize, basePointSize));
    }

    private void EndDraw()
    {
        squareTexture.gameObject.SetActive(false);
    }

    private void SetRect(Vector2 position, Vector2 size)
    {
        squareTexture.position = position;
        squareTexture.sizeDelta = size;
    }
}
