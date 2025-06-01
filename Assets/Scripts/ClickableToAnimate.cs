using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableToAnimate : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(!animator)
        {
           if(!TryGetComponent(out animator))
           {
                animator = GetComponentInChildren<Animator>();
                if(!animator)
                    Debug.LogError($"Object {name} does not have animator component");
           }
        }
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Click it");
    }



}
