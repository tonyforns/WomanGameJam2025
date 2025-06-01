using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        CheckAnimatorComponent();
    }


    private void CheckAnimatorComponent()
    {
        if (animator == null)
        {
            if (!TryGetComponent<Animator>(out animator))
            {
                Debug.LogError("Component character animator" + name + " dosent have animator component");
            }
        }
    }

    public void PlayAnim()
    {
        animator.Play("asdasd");
    }
}
