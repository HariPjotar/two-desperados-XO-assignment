using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIScaler : MonoBehaviour
{
    public GridLayoutGroup Group;

    private float _width, _height;

    private void Start()
    {
        _width = Screen.width;
        _height = Screen.height;

        float x = _width / 5f;
        float y = _height / 6.2f;

        Group.cellSize = new Vector2(x, y);
    }
}
