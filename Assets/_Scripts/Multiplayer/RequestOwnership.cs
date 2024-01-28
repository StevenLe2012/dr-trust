using Normal.Realtime;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RequestOwnership : MonoBehaviour
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRGrabInteractable xrGrabInteractable;

    private void OnEnable()
    {
        xrGrabInteractable.selectEntered.AddListener(RequestObjectOwnership);
    }
    
    private void OnDisable()
    {
        xrGrabInteractable.selectEntered.RemoveListener(RequestObjectOwnership);
    }

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
    }

}
