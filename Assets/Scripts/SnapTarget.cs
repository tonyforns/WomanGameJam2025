using UnityEngine;

public class SnapTarget : MonoBehaviour
{
    public string acceptedItemID; // ID del objeto que acepta
    [HideInInspector] public bool isOccupied = false;

    public bool CanAccept(string itemID)
    {
        return !isOccupied && itemID == acceptedItemID;
    }

    public void Occupy()
    {
        isOccupied = true;
    }
}