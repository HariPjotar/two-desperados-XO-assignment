using System;
using UnityEngine;
using UnityEngine.UI;

public class StyleUI : MonoBehaviour
{
    public int StyleID;

    public static Action<int> OnClickStyle;

    public Image SelectedImage;

    private void Start()
    {
        StyleUI.OnClickStyle += DeactivateSelectedImage;
    }

    private void OnDestroy()
    {
        StyleUI.OnClickStyle -= DeactivateSelectedImage;
    }

    public void OnClick() 
    {
        OnClickStyle?.Invoke(StyleID);

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
