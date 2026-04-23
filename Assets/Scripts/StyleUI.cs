using System;
using UnityEngine;
using UnityEngine.UI;

public class StyleUI : MonoBehaviour
{
    public int StyleID;

    public static Action<int> OnClickStyle;

    public Image SelectedImage;

    [Space]

    public AudioClip ClickAudio;

    private void Start()
    {
        OnClickStyle += DeactivateSelectedImage;
    }

    private void OnDestroy()
    {
        OnClickStyle -= DeactivateSelectedImage;
    }

    public void OnClick() 
    {
        OnClickStyle?.Invoke(StyleID);

        AudioManager.Instance.PlaySFX(ClickAudio);

        SelectedImage.enabled = true;
    }

    private void DeactivateSelectedImage(int id) 
    {
        if (StyleID == id)
            return;

        if(SelectedImage.enabled)
            SelectedImage.enabled = false;
    }
}
