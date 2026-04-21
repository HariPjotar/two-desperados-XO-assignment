using UnityEngine;
using UnityEngine.UI;

public class StylePopupUI : MonoBehaviour
{
    public StyleUI Style1;

    [Space]

    public GridLayoutGroup StyleParentGridLayout;

    public Vector2 _windowSize;

    private void OnEnable()
    {
        Style1.OnClick();

        _windowSize.x = GetComponent<RectTransform>().rect.width;
        _windowSize.y = GetComponent<RectTransform>().rect.height;

        StyleParentGridLayout.cellSize = new Vector2(_windowSize.x / 6.1f, _windowSize.x / 5.6f);
        StyleParentGridLayout.spacing = new Vector2(_windowSize.x / 10f, 0f);
    }
}
