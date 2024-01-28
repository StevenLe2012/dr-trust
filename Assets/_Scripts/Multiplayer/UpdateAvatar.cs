using Normal.Realtime;
using UnityEngine;

public class UpdateAvatar : MonoBehaviour
{
    [SerializeField] private Color doctorColor;
    [SerializeField] private Color patientColor;
    
    private RealtimeAvatarManager _realtimeAvatarManager;
    private RealtimeAvatar _realtimeAvatar;
    private string _localPlayerName;

    private void Awake()
    {
        _realtimeAvatarManager = GetComponent<RealtimeAvatarManager>();
    }

    private void OnEnable()
    {
        _realtimeAvatarManager.avatarCreated += OnAvatarCreated;
    }
    
    private void OnDisable()
    {
        _realtimeAvatarManager.avatarCreated -= OnAvatarCreated;
    }
    
    private void OnAvatarCreated(RealtimeAvatarManager avatarManager, RealtimeAvatar avatar, bool isLocalAvatar)
    {
        if (isLocalAvatar)
        {
            _realtimeAvatar = avatar;
        }
    }
    
    private void SetAvatarVisibility(RealtimeAvatar avatar, bool isVisible)
    {
        var renderers = avatar.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.enabled = isVisible;
        }
    }
    
    public void MakeAllAvatarsInvisible()
    {
        foreach (var avatar in _realtimeAvatarManager.avatars)
        {
            SetAvatarVisibility(avatar.Value, false);
        }
    }
    
    public void MakeAllAvatarsVisible()
    {
        foreach (var avatar in _realtimeAvatarManager.avatars)
        {
            SetAvatarVisibility(avatar.Value, true);
        }
    }


    public void SaveLocalPlayerName(string name)
    {
        _localPlayerName = name;
        _realtimeAvatar.GetComponentInChildren<NameSync>().SetText(_localPlayerName);
    }
    
    public void SetPatientColor()
    {
        _realtimeAvatar.GetComponentInChildren<ColorSync>().SetColor(patientColor);
    }
    
    public void SetDoctorColor()
    {
        _realtimeAvatar.GetComponentInChildren<ColorSync>().SetColor(doctorColor);
    }
}
