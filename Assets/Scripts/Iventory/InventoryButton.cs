using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class InventoryButton : MonoBehaviour, IPointerEnterHandler
{
    private void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameMaster.Instance.TryToGetItem(out GameObject item))
        {
            Debug.Log("asdasd");

            InventorySystem.Instance.AddItem(item);
            GameMaster.Instance.ReleaseItem(item);
        }
    }

}
