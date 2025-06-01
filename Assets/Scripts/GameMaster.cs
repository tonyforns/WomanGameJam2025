using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{
    [SerializeField]private GameObject grabbedItem;

    public void GrabItem(GameObject item)
    {
        grabbedItem = item;
    }

    public void ReleaseItem(GameObject item) {
        if (grabbedItem == item)
        {
            grabbedItem = null;
        }
    }

    public bool TryToGetItem(out GameObject item)
    {
        item = grabbedItem;
        return grabbedItem != null;
    }
}
