using Normal.Realtime;
using TMPro;
using UnityEngine;

public class NameSync : RealtimeComponent<NameSyncModel>
{
    [SerializeField] private TextMeshPro textMeshProText;
    
    protected override void OnRealtimeModelReplaced(NameSyncModel previousModel, NameSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.nameDidChange -= DidNameChange;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                // Set the initial data
                currentModel.name = textMeshProText.text;
            }
            
            UpdateName();
            
            // Register for events so we'll know if the name changes later
            currentModel.nameDidChange += DidNameChange;
        }
    }
    
    private void DidNameChange(NameSyncModel model, string value)
    {
        UpdateName();
    }
    
    private void UpdateName()
    {
        textMeshProText.text = model.name;
    }

    public void SetText(string name)
    {
        model.name = name;
    }
    
}
