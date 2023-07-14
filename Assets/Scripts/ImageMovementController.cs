using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageMovementController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RawImage image;

    private bool canMove = true;
    private RectTransform canvasRectTransform;
    private RectTransform imageRectTransform;
    private Vector2 originalImagePosition;
    private bool isDragging = false;

    private void Start()
    {
        canvasRectTransform = image.canvas.GetComponent<RectTransform>();
        imageRectTransform = image.GetComponent<RectTransform>();
        originalImagePosition = imageRectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canMove && IsCursorOverImage())
        {
            isDragging = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canMove && isDragging)
        {
            Vector2 localCursor;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out localCursor);
            imageRectTransform.anchoredPosition = localCursor;
        }
    }

    private bool IsCursorOverImage()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageRectTransform, Input.mousePosition, null, out localPoint);

        Rect imageRect = new Rect(0, 0, imageRectTransform.rect.width, imageRectTransform.rect.height);

        return imageRect.Contains(localPoint);
    }

    public void SetCanMove(bool moveStatus)
    {
        canMove = moveStatus;
        if (!canMove)
        {
            imageRectTransform.anchoredPosition = originalImagePosition;
            isDragging = false;
        }
    }
}
