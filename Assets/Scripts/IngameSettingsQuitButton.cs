using UnityEngine;
using UnityEngine.UI;

public class IngameSettingsQuitButton : MonoBehaviour
{
    public AudioClip Audio;

    private void OnEnable()
    {
        AudioManager.Instance.PlaySFX(Audio);
        GetComponent<Button>().onClick.AddListener(() => { GameManager.Instance.LoadMenuScene(); });
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }
}
