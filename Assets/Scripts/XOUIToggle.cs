using System;
using UnityEngine;
using UnityEngine.Events;

public class XOUIToggle : MonoBehaviour
{
    public bool DefaultValue;

    [Space]

    public bool IsOn;

    public GameObject ONImage;
    public GameObject OFFImage;

    [Space]

    public UnityEvent OnToggle;

    [Space]

    public AudioClip Audio;

    protected void Start()
    {
        IsOn = DefaultValue;
        ToggleImages();
    }

    public void OnClickToggle() 
    {
        OnToggle?.Invoke();
        IsOn = !IsOn;

        ToggleImages();

        if (Audio)
            AudioManager.Instance.PlaySFX(Audio);
    }

    private void ToggleImages() 
    {
        if (IsOn) 
        {
            ONImage.SetActive(true);
            OFFImage.SetActive(false);
            return;
        }

        ONImage.SetActive(false);
        OFFImage.SetActive(true);
    }
}
