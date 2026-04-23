using UnityEngine;

public class UIToggleMusic : XOUIToggle
{
    private new void Start()
    {
        base.Start();
        OnToggle.AddListener(() => { AudioManager.Instance.MuteMusic(); });

        if (AudioManager.Instance.MusicSource.volume <= 0)
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
