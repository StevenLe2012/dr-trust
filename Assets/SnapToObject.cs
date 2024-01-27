using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToObject : MonoBehaviour
{
    public Transform snapPoint;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    private bool isSnapped = false;
    private float rotationSpeed = 6.0f; // Rotation speed in RPM

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grabInteractable.selectExited.AddListener(SnapToPosition);
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void SnapToPosition(SelectExitEventArgs args)
    {
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;

        // Disable physics interactions and start rotation
        rb.isKinematic = true;
        isSnapped = true;
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Re-enable physics interactions and stop rotation
        rb.isKinematic = false;
        isSnapped = false;
    }

    void Update()
    {
        if (isSnapped)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
        float rotationThisFrame = rotationSpeed * 360 / 60 * Time.deltaTime; // Calculate rotation per frame
        transform.Rotate(Vector3.up, rotationThisFrame); // Adjust this if you want to rotate around a different axis
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(SnapToPosition);
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
