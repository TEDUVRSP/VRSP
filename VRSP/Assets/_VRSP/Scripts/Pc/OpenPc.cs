using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPc : MonoBehaviour
{
    #region Variables
    [SerializeField] private Vector3 targetPositionOffset;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private InputActionProperty triggerInput;
    private bool _isOpen=false;
    private bool _inCollision;

    #endregion

    #region Unity Event Functions

    
    private void OnTriggerEnter(Collider other)
    {
        _inCollision = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
      
        _inCollision = false;
        
    }

    private void OnEnable()
    {
        //run Open() when trigger is pressed
        triggerInput.action.started += _ => Interact();
        triggerInput.action.Enable();
    }
    
    private void OnDisable()
    {
        triggerInput.action.started -= _ => Interact();
        triggerInput.action.Disable();
    }
    #endregion

    #region Private Functions

    private void Interact()
    {
        if (!_inCollision) return;
        if (!_isOpen)
        {
            
            var targetLocalPosition = targetTransform.localPosition + targetPositionOffset;
            var targetPosition = targetTransform.TransformPoint(targetLocalPosition);
            var targetRotation = targetTransform.eulerAngles.y;
            PcManager.Instance.Open(targetPosition, targetRotation);
            _isOpen = true;
        }
        else
        {
            PcManager.Instance.Close();
            _isOpen = false;
        }

    }

    #endregion
    
}
