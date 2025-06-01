using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPreviewSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RawImage slotImage;
    [SerializeField] private Camera slotCamera;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Button slotButton;


    private GameObject savedItem;
    public Vector3 modelOffset = Vector3.zero;
    public float renderTextureSize = 50;

    [SerializeField] 

    private void Awake()
    {
        RenderTexture rt = new RenderTexture((int)renderTextureSize, (int)renderTextureSize, 16);
        rt.Create();
        slotCamera.targetTexture = rt;
        slotImage.texture = rt;

    }

    public void SetItem(GameObject instantiatedModel)
    {
        instantiatedModel.layer = LayerMask.NameToLayer("InventoryPreview");
        foreach (Transform child in instantiatedModel.GetComponentsInChildren<Transform>())
            child.gameObject.layer = LayerMask.NameToLayer("InventoryPreview");
        instantiatedModel.transform.SetParent(transform);
    }

    internal void Show(GameObject item)
    {
        GameObject newItem = Instantiate(item);
        newItem.transform.parent = parentTransform;
        newItem.transform.localPosition = Vector3.zero;
        SetItem(newItem);
        savedItem = item;
        item.gameObject.SetActive(false);
    }

    internal bool HaveItem(GameObject item)
    {
        return savedItem = item;
    }

    private void GetItem()
    {
        savedItem.gameObject.SetActive(true);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        savedItem.transform.position = worldPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetItem();
    }
}