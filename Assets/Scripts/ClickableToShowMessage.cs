using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableToShowMessage : MonoBehaviour
{
    [SerializeField] private GameObject message;

    private void OnMouseUpAsButton()
    {
        message.SetActive(true);
        Invoke("HideMessage", 5);
    }

    private void HideMessage()
    {
        message.SetActive(false);
    }

}
