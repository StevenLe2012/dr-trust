using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorController : MonoBehaviour
{
    public ActionBasedController controller;
    public XRRayInteractor rayInteractor;

    private bool isTriggerPressed = false;

    private LineRenderer lineRenderer;
    
    void Start()
    {
        // Get the LineRenderer component from the XRInteractorLineVisual
        lineRenderer = GetComponent<LineRenderer>();

        // // Subscribe to the action events
        controller.activateAction.action.performed += OnSelectPerformed;
        controller.activateAction.action.canceled += OnSelectCanceled;
    }

    // This method will be called when the select action is performed (i.e., the trigger button is pressed)
    private void OnSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Change the layer mask
        rayInteractor.raycastMask = LayerMask.GetMask("TransparentFX");

        // Change line color to red
        if (lineRenderer != null)
        {
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
    }

    // This method will be called when the select action is canceled (i.e., the trigger button is released)
    private void OnSelectCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { 
        // Revert the layer mask
        rayInteractor.raycastMask = LayerMask.GetMask("Default");
        
        // Revert line color to original
        if (lineRenderer != null)
        {
            lineRenderer.startColor = Color.white; // Assuming white is the original color
            lineRenderer.endColor = Color.white;
        }
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (controller != null && controller.selectAction != null)
        {
            controller.selectAction.action.performed -= OnSelectPerformed;
            controller.selectAction.action.canceled -= OnSelectCanceled;
        }
    }
}
