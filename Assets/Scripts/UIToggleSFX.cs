using UnityEngine;

public class UIToggleSFX : XOUIToggle
{
    private new void Start()
    {
        base.Start();
        OnToggle.AddListener(() => { AudioManager.Instance.MuteSFX(); });

        if(AudioManager.Instance.SFXSource.volume <= 0)
        {
            IsOn = false;
            ToggleImages();
        }
    }

    private void OnDestroy()
    {
        OnToggle.RemoveAllListeners();
    }
}
