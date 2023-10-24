using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragResize : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 offset;
    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private Vector3 rotationVector;
    private RectTransform canvasRectTransform;
    private Vector2 touch1Start, touch2Start;
    private float startRotation;

    private bool isDragging = false;
    private bool isPinching = false;

    void Start()
    {
        canvasRectTransform = GetComponentInParent<Canvas>().transform as RectTransform;
        initialScale = transform.localScale;
        initialPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition))
        {
            offset = (Vector2)transform.localPosition - localPointerPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 localPointerPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition))
            {
                transform.localPosition = localPointerPosition + offset;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        // Do something when the dragging ends (optional).
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            touch1Start = touch1.position;
            touch2Start = touch2.position;
            startRotation = transform.localEulerAngles.z;
            initialDistance = Vector2.Distance(touch1.position, touch2.position);
            isPinching = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        initialDistance = 0f;
        isPinching = false;
    }

    void Update()
    {
        if (isPinching)
        {
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                Vector2 currentDir = touch2.position - touch1.position;
                Vector2 initialDir = touch2Start - touch1Start;
                float rotationAngle = Vector2.SignedAngle(initialDir, currentDir);

                // Adjust the rotation angle based on the initial rotation
                float newRotation = startRotation + rotationAngle;
                rotationVector.z = newRotation;
                transform.localEulerAngles = rotationVector;

                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;
            }
        }
    }
}