using UnityEngine;
using UnityEngine.UI;

public class UIButtonAudio : MonoBehaviour
{
    public AudioClip AudioClip;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { AudioManager.Instance.PlaySFX(AudioClip); });
    }
}
