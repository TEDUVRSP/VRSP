using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysics : MonoBehaviour
{
    [SerializeField] private Transform VRHandController;
    [SerializeField] private bool hapticFeedbackOnCollision;
    
    [SerializeField] private GameObject nonPhysicsHand;
    private Renderer nonPhysicsHandRenderer;
    [SerializeField] private float nonPhysicsHandRendererThreshold;
    [SerializeField] private bool hapticFeedbackOnNonPhysicsHand;
    private ActionBasedController _actionBasedController;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        nonPhysicsHandRenderer = nonPhysicsHand.GetComponentInChildren<Renderer>();
        _actionBasedController = VRHandController.GetComponent<ActionBasedController>();

        nonPhysicsHandRenderer.enabled = false;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, VRHandController.position);
        if(distance > nonPhysicsHandRendererThreshold)
        {
            nonPhysicsHandRenderer.enabled = true;
            if (!hapticFeedbackOnNonPhysicsHand) return;
            _actionBasedController.SendHapticImpulse(0.1f, 0.1f);
        }
        else
        {
            nonPhysicsHandRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move the hand to the controller position
        _rb.velocity = (VRHandController.position - transform.position) / Time.fixedDeltaTime;
        // rotate the hand to the controller rotation
        Quaternion deltaRotation = VRHandController.rotation * Quaternion.Inverse(transform.rotation);
        deltaRotation.ToAngleAxis(out float angle, out Vector3 axis);
        Vector3 deltaRotationInDegrees = angle * axis;
        _rb.angularVelocity = deltaRotationInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (!hapticFeedbackOnCollision) return;

        _actionBasedController.SendHapticImpulse(0.1f, 0.1f);
    }
}
