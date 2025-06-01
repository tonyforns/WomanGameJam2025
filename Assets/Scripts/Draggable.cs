using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Camera mainCamera;

    private Vector3 startPosition; // Posicion inicial
    private bool isOverValidZone = false;
    private Transform currentSnapZone;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position; //Guarda la posicion inicial al hacer click
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
        GameMaster.Instance.GrabItem(gameObject); // Notifica al GameMaster que se ha agarrado un item
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
        if (isOverValidZone)
        {
            transform.position = currentSnapZone.position;
        }
        else
        {
            //si no volver a la posicion original
            transform.position = startPosition;
        }
        // reseteo de banderas o flasgs
        isOverValidZone = false;
        currentSnapZone = null;
        GameMaster.Instance.ReleaseItem(gameObject); // Notifica al GameMaster que se ha agarrado un item

    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Mathf.Abs(mainCamera.WorldToScreenPoint(transform.position).z);
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entre");
        if (collision.gameObject.CompareTag("SnapZone"))
        {
            isOverValidZone = true;
            currentSnapZone = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("SnapZone"))
        {
            isOverValidZone = false;
            currentSnapZone = null;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SnapZone"))
        {
            isOverValidZone = false;
            currentSnapZone = null;
        }
    }
}