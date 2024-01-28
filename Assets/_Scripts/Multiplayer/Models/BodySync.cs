using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;

public class BodySync : RealtimeComponent<BodySyncModel>
{
    [SerializeField] private GameObject body; // The item to be synced

    protected override void OnRealtimeModelReplaced(BodySyncModel previousModel, BodySyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.isActiveDidChange -= DidActiveStateChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                // Set the initial active state
                currentModel.isActive = body.activeSelf;
            }
            
            UpdateActiveState();
            
            // Register for events to know when the active state changes
            currentModel.isActiveDidChange += DidActiveStateChange;
        }
    }
    
    private void DidActiveStateChange(BodySyncModel model, bool isActive)
    {
        UpdateActiveState();
    }
    
    private void UpdateActiveState()
    {
        // Set the active state of the item based on the model
        body.SetActive(model.isActive);
    }

    public void ToggleActiveState()
    {
        // Toggle the active state and update the model
        bool currentState = model.isActive;
        model.isActive = !currentState;
    }
}
