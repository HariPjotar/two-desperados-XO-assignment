using UnityEngine;

public class StylePopupUI : MonoBehaviour
{
    public StyleUI Style1;

    private void OnEnable()
    {
        Style1.OnClick();
    }
}
