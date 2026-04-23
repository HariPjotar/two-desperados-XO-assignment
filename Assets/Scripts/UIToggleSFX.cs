using UnityEngine;

public class UIToggleSFX : XOUIToggle
{
    private new void Start()
    {
        base.Start();
        OnToggle.AddListener(() => { AudioManager.Instance.MuteSFX(); });
    }

    private void OnDestroy()
    {
        OnToggle.RemoveAllListeners();
    }
}
