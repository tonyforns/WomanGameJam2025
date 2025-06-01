using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    [SerializeField] private GameObject containerPrefab;
    [SerializeField] private Transform parentContainer;
    [SerializeField] private GameObject box;

    private List<InventoryPreviewSlot> itemList;

    internal override void Awake()
    {
        base.Awake();
        itemList = new List<InventoryPreviewSlot>();
        //AddItem(Instantiate(box));

    }
    public void AddItem(GameObject item)
    {
        InventoryPreviewSlot newItem = Instantiate(containerPrefab, parentContainer).GetComponent<InventoryPreviewSlot>();

        newItem.Show(item);

        itemList.Add(newItem);
    }

    public void RemoveItem(GameObject item)
    {
        InventoryPreviewSlot itemToRemove =  null;
        foreach (InventoryPreviewSlot itemContainer in itemList) { 
            if(itemContainer.HaveItem(item))
            {
                itemToRemove = itemContainer;
                break;
            }
        }
        itemList.Remove(itemToRemove);
        Destroy(itemToRemove.gameObject);
    }
}
