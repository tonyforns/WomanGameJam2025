using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : UIHoverEffect
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (GameMaster.Instance.TryToGetItem(out GameObject item))
        {
            base.OnPointerEnter(eventData);
            InventorySystem.Instance.AddItem(item);
            GameMaster.Instance.ReleaseItem(item);
        }
    }

}
