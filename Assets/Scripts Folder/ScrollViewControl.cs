using UnityEngine;

public class ScrollViewControl : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    public RectTransform contentRectTransform;
    public float scrollSpeed = 10.0f; // Adjust this value to control the scrolling speed.
    public float minY = 0; // Minimum Y position.
    public float maxY = 2708; // Maximum Y position (the height of your scrollable area).

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchEndPos = touch.position;
                Vector2 swipeDelta = touchEndPos - touchStartPos;
                ScrollContent(swipeDelta.y);
                touchStartPos = touchEndPos;
            }
        }
    }

    void ScrollContent(float deltaY)
    {
        // Calculate the new anchored position of the Content GameObject.
        Vector2 newPosition = contentRectTransform.anchoredPosition;
        newPosition.y += deltaY * scrollSpeed;

        // Clamp the new Y position to stay within minY and maxY.
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Set the new anchored position.
        contentRectTransform.anchoredPosition = newPosition;
    }
}