using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorController : MonoBehaviour
{
    public ActionBasedController controller;
    public XRRayInteractor rayInteractor;

    public LayerMask originalLayerMask;
    public LayerMask modifiedLayerMask;





    private bool isTriggerPressed = false;

    private Color originalColor = new Color(0, 0.625f, 1, 1);
    private Color transparentColor = new Color(0, 0, 0, 0);

    private LineRenderer lineRenderer;

    [SerializeField] private InputActionProperty inputAction;



void Start()
    {
        // Get the LineRenderer component from the XRInteractorLineVisual
        lineRenderer = GetComponent<LineRenderer>();

        // // Subscribe to the action events
        controller.activateAction.action.performed += OnSelectPerformed;
        controller.activateAction.action.canceled += OnSelectCanceled;
    }
    // private void Update()
    // {
    //     if (inputAction.action.WasPressedThisFrame())
    //     {
    //             // Change the layer mask
    //         rayInteractor.interactionLayerMask = modifiedLayerMask;

    //         // Change line color to red
    //         if (lineRenderer != null)
    //             {
    //                 lineRenderer.startColor = Color.red;
    //                 lineRenderer.endColor = Color.red;
    //             }
    //     }
    //     else if(inputAction.action.WasReleasedThisFrame())
    //     {
    //             // Revert the layer mask
    //         rayInteractor.interactionLayerMask = originalLayerMask;

    //         // Revert line color to original
    //         if (lineRenderer != null)
    //         {
    //             lineRenderer.startColor = Color.white; // Assuming white is the original color
    //             lineRenderer.endColor = Color.white;
    //         }
    //     }
    // }

    // This method will be called when the select action is performed (i.e., the trigger button is pressed)
    private void OnSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        print("PERFORMEND ACTION");
        // Change the layer mask
        rayInteractor.interactionLayerMask = LayerMask.GetMask("TransparentFX");

        // Change line color to red
        if (lineRenderer != null)
        {
            lineRenderer.startColor = Color.red;
            // lineRenderer.s
            lineRenderer.endColor = Color.red;
        }
        else
        {
            print("Trash");
        }
    }

    // This method will be called when the select action is canceled (i.e., the trigger button is released)
    private void OnSelectCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        print("CANCELLED ACTION");
        // Revert the layer mask
        rayInteractor.interactionLayerMask = LayerMask.GetMask("Default");

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
