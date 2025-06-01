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
    public Vector2 renderTextureSize = new Vector2(116, 113);

    [SerializeField] 

    private void Awake()
    {
        RenderTexture rt = new RenderTexture((int)renderTextureSize.x, (int)renderTextureSize.y, 16);
        rt.Create();
        slotCamera.targetTexture = rt;
        slotImage.texture = rt;

        slotButton.onClick.AddListener(GetItem);
    }

    public void SetItem(GameObject instantiatedModel)
    {
        instantiatedModel.layer = LayerMask.NameToLayer("InventoryPreview");
        foreach (Transform child in instantiatedModel.GetComponentsInChildren<Transform>())
            child.gameObject.layer = LayerMask.NameToLayer("InventoryPreview");
    }

    internal void Show(GameObject item)
    {
        GameObject newItem = Instantiate(item, parentTransform);
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
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 3 ;
        savedItem.transform.position = worldPos;
        Destroy(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetItem();
    }
}