using Normal.Realtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorController : MonoBehaviour
{
    public GameObject circlePrefab;
    public float paintInterval = 0.1f;
    private float timeSinceLastPaint = 0.0f;
    public ActionBasedController controller;
    public XRRayInteractor rayInteractor;

    private bool isTriggerPressed = false;
    private int _defaultLayer;

    private XRInteractorLineVisual lineVisual;
    
    void Start()
    {
        // Get the XRInteractorLineVisual component from the XRInteractorLineVisual
        lineVisual = GetComponent<XRInteractorLineVisual>();
        _defaultLayer = rayInteractor.raycastMask.value;

        // // Subscribe to the action events
        controller.activateAction.action.performed += OnSelectPerformed;
        controller.activateAction.action.canceled += OnSelectCanceled;
    }

    void Update(){
        if (isTriggerPressed)
        {
            Paint();
        }
    }

    private void Paint()
    {
        if (Time.time - timeSinceLastPaint >= paintInterval)
        {
            timeSinceLastPaint = Time.time;
            
            // Perform the raycast using the ray interactor
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                // Check if the hit object's layer is in the paintLayerMask
                if (((1 << hit.collider.gameObject.layer) & rayInteractor.raycastMask) != 0)
                {
                    // Instantiate the circle at the hit location, facing up based on the hit normal
                    // Instantiate(circlePrefab, hit.point, Quaternion.LookRotation(hit.normal));
                    Realtime.Instantiate(circlePrefab.name, position: hit.point, rotation: Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }

    // This method will be called when the select action is performed (i.e., the trigger button is pressed)
    private void OnSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Change the layer mask
        rayInteractor.raycastMask = LayerMask.GetMask("TransparentFX") | LayerMask.GetMask("UI");

        isTriggerPressed = true;

        // Change line color to red
        if (lineVisual != null)
        {
            // gradient from solid red to transparent
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );
            lineVisual.invalidColorGradient = gradient;
        }
    }

    // This method will be called when the select action is canceled (i.e., the trigger button is released)
    private void OnSelectCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    { 
        // Revert the layer mask
        // rayInteractor.raycastMask = LayerMask.GetMask("Default");

        isTriggerPressed = false;
        rayInteractor.raycastMask = _defaultLayer;
        
        // Revert line color to original
        if (lineVisual != null)
        {
            // gradient from solid white to transparent
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );
            lineVisual.invalidColorGradient = gradient;
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
