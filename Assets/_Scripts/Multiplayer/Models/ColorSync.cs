using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Random = UnityEngine.Random;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private Color color;
    private Color lastColor;

    private void Start()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        model.color = randomColor;
    }
    
    private void Update()
    {
        if (color != lastColor)
        {
            model.color = color;
            lastColor = color;
        }
    }

    private void UpdateMeshRendererColor()
    {
        foreach (var renderer in meshRenderers)
        {
            foreach (var mat in renderer.materials)
            {
                mat.color = model.color;
            }
        }
    }
    
    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.colorDidChange -= DidColorChange;
        }

        if (currentModel.isFreshModel)
        {
            // Register for events so we'll know if the color changes later
            currentModel.colorDidChange += DidColorChange;
        }
        
        // Update the mesh renderer color
        UpdateMeshRendererColor();
    }

    private void DidColorChange(ColorSyncModel color, Color value)
    {
        UpdateMeshRendererColor();
    }
    
    public void SetColor(Color color)
    {
        model.color = color;
    }

}
