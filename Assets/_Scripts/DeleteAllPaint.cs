using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteAllPaint : MonoBehaviour
{
    public ActionBasedController controller; // Reference to your XR Controller
    public LayerMask trashCanLayer; // Layer mask to identify the trash can
    public string trashCanTag = "TrashCan"; // Optionally use a tag to identify the trash can
    
    private bool isTriggerPressed = false;
    private bool hasTriggeredAlready = false;

    private void Start()
    {
        // Subscribe to the action events
        controller.activateAction.action.performed += OnSelectPerformed;
        controller.activateAction.action.canceled += OnSelectCanceled;
    }
    void Update()
    {
        if (isTriggerPressed && hasTriggeredAlready == false)
        {
            CheckForTrashCanInteraction();
        }
    }

    private void CheckForTrashCanInteraction()
    {
        RaycastHit hit;
        // Perform a raycast from the controller
        if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, Mathf.Infinity, trashCanLayer))
        {
            // Check if the raycast hits an object tagged as "TrashCan"
            if (hit.collider.CompareTag(trashCanTag))
            {
                // Call the method to delete all paint
                DeletePaint();
                hasTriggeredAlready = true;
            }
        }
    }

    private void OnSelectPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isTriggerPressed = true;
    }
    
    private void OnSelectCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        isTriggerPressed = false;
        hasTriggeredAlready = false;
    }

    private void DeletePaint()
    {
        // Find all game objects tagged with "PaintSphere"
        GameObject[] paintSpheres = GameObject.FindGameObjectsWithTag("PaintSphere");

        // Iterate through each game object and destroy it
        foreach (GameObject paintSphere in paintSpheres)
        {
            Destroy(paintSphere);
        }
    }
}
