using UnityEngine;

[CreateAssetMenu(fileName = "New GameSettings", menuName = "Data/GameSettings")]
public class GameSettings : ScriptableObject
{
    public Sprite XSprite;
    public Color XColor;

    [Space]

    public Sprite OSprite;
    public Color OColor;
}