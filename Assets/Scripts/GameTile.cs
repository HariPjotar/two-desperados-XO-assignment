using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTile : MonoBehaviour
{
    public TileValue Value;

    [Space]

    public Image ValueImage;
    public GameObject HoverImage;

    [Space]

    public Sprite XSprite;
    public Sprite OSprite;

    [Space]

    public AnimationCurve DrawCurve;
    public AudioClip XAudio;
    public AudioClip OAudio;

    [Space]

    private bool _isXTurn;
    private bool _wasClickedAlready;
    private bool _isGameOver = false;

    public static Action OnClickTile;
    public static Action<TileValue> OnPlaceSymbol;

    private void Start()
    {
        LoadStyle();

        InputManager.OnBeginTurn += OnBeginTurn;
        BoardManager.OnWinGame += OnWinGame;

        HoverImage.transform.rotation = Quaternion.Euler(0f, 0f, 90f * UnityEngine.Random.Range(0, 4));
    }

    private void OnDestroy()
    {
        InputManager.OnBeginTurn -= OnBeginTurn;
        BoardManager.OnWinGame -= OnWinGame;
    }

    private void OnBeginTurn(CurrentTurn context) 
    {
        _isXTurn = context.Equals(CurrentTurn.PLAYER1);
    }

    public void TileClickLogic() 
    {
        if (_isGameOver)
            return;

        if (_wasClickedAlready)
            return;

        _wasClickedAlready = true;

        HoverImage.GetComponent<Image>().enabled = false;

        if (_isXTurn)
        {
            ValueImage.sprite = XSprite;
            Value = TileValue.X;
            AudioManager.Instance.PlaySFX(XAudio);
        }
        else 
        {
            ValueImage.sprite = OSprite;
            Value = TileValue.O;
            AudioManager.Instance.PlaySFX(OAudio);
        }

        ValueImage.transform.DOScale(1.05f, 0.2f).SetEase(DrawCurve);

        OnPlaceSymbol?.Invoke(Value);
        OnClickTile?.Invoke();
    }

    private void LoadStyle() 
    {
        GameSettings styleSettings = GameManager.Instance.ChosenStyle;

        if (styleSettings == null)
            styleSettings = GameManager.Instance.FallbackStyle;

        XSprite = styleSettings.XSprite;
        OSprite = styleSettings.OSprite;
    }

    private void OnWinGame(GameWinner context, Vector2 context1, Vector2 context2) 
    {
        HoverImage.GetComponent<Image>().enabled = false;
        _isGameOver = true;
    }
}
public enum TileValue 
{
    NONE, X, O
}
