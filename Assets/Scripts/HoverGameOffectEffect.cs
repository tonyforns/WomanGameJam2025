using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGameOffectEffect : MonoBehaviour
{
    private void OnMouseEnter()
    {
        gameObject.transform.localScale = 1.1f * Vector3.one;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = Vector3.one;
    }
}
