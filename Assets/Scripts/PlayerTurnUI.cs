using TMPro;
using UnityEngine;

public class PlayerTurnUI : MonoBehaviour
{
    public TextMeshProUGUI TurnDisplayText;

    public Color Player1Color;
    public Color Player2Color;

    private void Start()
    {
        InputManager.OnBeginTurn += OnBeginTurn;

        GameSettings settings = GameManager.Instance.ChosenStyle;
        Player1Color = settings.XColor;
        Player2Color = settings.OColor;
    }

    private void OnDestroy()
    {
        InputManager.OnBeginTurn -= OnBeginTurn;
    }

    private void OnBeginTurn(CurrentTurn context) 
    {
        if (context.Equals(CurrentTurn.PLAYER1))
            TurnDisplayText.text = "Current turn:" + $"<color=#{ColorUtility.ToHtmlStringRGBA(Player1Color)}> Player 1 (X)</color>";
        else
            TurnDisplayText.text = "Current turn:" + $"<color=#{ColorUtility.ToHtmlStringRGBA(Player2Color)}> Player 2 (O)</color>";
    }
}
