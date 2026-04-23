using UnityEngine;

public class UIToggleMusic : XOUIToggle
{
    private new void Start()
    {
        base.Start();
        OnToggle.AddListener(() => { AudioManager.Instance.MuteMusic(); });
    }

    private void OnDestroy()
    {
        OnToggle.RemoveAllListeners();
    }
}
