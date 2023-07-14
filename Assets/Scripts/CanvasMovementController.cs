using UnityEngine;
using UnityEngine.UI;

public class RawImageMovement : MonoBehaviour
{
    private RawImage rawImage;
    private RectTransform rawImageRectTransform;
    private bool isDragging = false;

    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        rawImageRectTransform = rawImage.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse click position is within the bounds of the RawImage
            if (IsMouseOverRawImage())
            {
                isDragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            // Convert the mouse position to local coordinates of the RawImage's parent canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImageRectTransform.parent as RectTransform, Input.mousePosition, null, out Vector2 localPosition);
            // Set the RawImage's position based on the local mouse position
            rawImageRectTransform.localPosition = localPosition;
        }
    }

    private bool IsMouseOverRawImage()
    {
        // Get the position of the RawImage in screen space
        Vector3[] corners = new Vector3[4];
        rawImageRectTransform.GetWorldCorners(corners);

        // Check if the mouse position is within the bounds of the RawImage
        Rect rawImageBounds = new Rect(corners[0], corners[2] - corners[0]);
        return rawImageBounds.Contains(Input.mousePosition);
    }
}
