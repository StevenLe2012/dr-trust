using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using CommonUsages = UnityEngine.XR.CommonUsages;

public class MenuCanvasController : MonoBehaviour
{
    // public XRController rightController;
    [SerializeField] private InputActionProperty inputAction;
    public Canvas canvas;
    public float distanceFromPlayer = 2.0f;
    private bool isCanvasVisible = false;

    private void Update()
    {
        if (inputAction.action.WasPressedThisFrame())
        {
            ToggleCanvas();
        }
        
        // if (rightController)
        // {
        //     CheckInput();
        // }
    }

    private void CheckInput()
    {
        // if (inputAction.action.WasPressedThisFrame())
        // {
        //     ToggleCanvas();
        // }
        // if (rightController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        // {
        //     ToggleCanvas();
        // }
    }

    private void ToggleCanvas()
    {
        isCanvasVisible = !isCanvasVisible;
        canvas.gameObject.SetActive(isCanvasVisible);

        if (isCanvasVisible)
        {
            PositionCanvasInFrontOfPlayer();
        }
    }

    private void PositionCanvasInFrontOfPlayer()
    {
        Camera mainCamera = Camera.main;
        Vector3 playerPosition = mainCamera.transform.position;
        Vector3 playerForward = mainCamera.transform.forward;

        canvas.transform.position = playerPosition + playerForward * distanceFromPlayer;
        canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - playerPosition);
    }
}
