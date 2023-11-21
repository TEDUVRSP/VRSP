using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportationRayActivator : MonoBehaviour
{
    [SerializeField] private InputActionProperty teleportationRayAction;
    [SerializeField] private GameObject teleportationRay;

    private void OnEnable()
    {
        teleportationRayAction.action.Enable();
    }

    private void OnDisable()
    {
        teleportationRayAction.action.Disable();
    }

    private void Update()
    {
        teleportationRay.SetActive(teleportationRayAction.action.ReadValue<Vector2>().y > 0.5f);
    }
}
