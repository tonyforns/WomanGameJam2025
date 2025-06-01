using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
    }

    void OnMouseDrag()
    {
        if (!isDragging) return;
        Vector3 mousePos = GetMouseWorldPosition();
        transform.position = mousePos + offset;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Mathf.Abs(mainCamera.WorldToScreenPoint(transform.position).z);
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}