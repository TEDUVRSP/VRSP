using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty pinchAnimationAction;
    [SerializeField] private InputActionProperty grabAnimationAction;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        pinchAnimationAction.action.Enable();
        grabAnimationAction.action.Enable();
    }

    private void OnDisable()
    {
        pinchAnimationAction.action.Disable();
        grabAnimationAction.action.Disable();
    }

    private void Update()
    {
        animator.SetFloat("Trigger", pinchAnimationAction.action.ReadValue<float>());
        animator.SetFloat("Grip", grabAnimationAction.action.ReadValue<float>());
        if(animator.GetFloat("Trigger") > 0.5f)
        {
            Debug.Log("Trigger");
        }
    }
}