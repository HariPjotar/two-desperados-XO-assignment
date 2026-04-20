using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StrikeLine : MonoBehaviour
{
    private Image _fillImage;

    public void Start()
    {
        _fillImage = GetComponent<Image>();

        BoardManager.OnWinGame += OnWinGame;
    }

    private void OnDestroy()
    {
        BoardManager.OnWinGame -= OnWinGame;
    }

    public void OnWinGame(GameWinner context, Vector2 tile1Pos, Vector2 tile2Pos)
    {
        transform.position = tile1Pos;
        transform.up = tile1Pos - tile2Pos;

        if(context.Equals(GameWinner.X))
            _fillImage.color = GameManager.Instance.ChosenStyle.XColor;
        else
            _fillImage.color = GameManager.Instance.ChosenStyle.OColor;

        float fillValue = 0f;

        DOTween.To(() => fillValue, x => fillValue = x, 1f, 0.65f).OnUpdate(() => 
        {
            _fillImage.fillAmount = fillValue;
        }).OnComplete(() => 
        {
            _fillImage.fillOrigin = 1;
            DOTween.To(() => fillValue, x => fillValue = x, 0f, 0.65f).OnUpdate(() =>
            {
                _fillImage.fillAmount = fillValue;
            });
        });
    }
}
