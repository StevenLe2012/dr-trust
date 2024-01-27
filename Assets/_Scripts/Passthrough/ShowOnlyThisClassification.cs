using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShowOnlyThisClassification : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private PlaneClassification classification;
    
    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }
    
    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }
    
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        List<ARPlane> newPlane = args.added;
        foreach (var item in newPlane)
        {
            if (item.classification != classification)
            {
                Renderer itemRenderer = item.GetComponent<Renderer>();
                Destroy(itemRenderer);
            }
        }
    }
    
}
