using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public BoardManager BoardManager;
    public Timer Timer;

    [Space]

    public TextMeshProUGUI EndText;
    public TextMeshProUGUI TimeText;

    [Space]

    public Button RetryButton;
    public Button ExitButton;

    private Color P1Color;
    private Color P2Color;

    private void Start()
    {
        RetryButton.onClick.AddListener(() => { GameManager.Instance.ReloadScene(); });
        ExitButton.onClick.AddListener(() => { GameManager.Instance.LoadMenuScene(); });
    }

    private void OnEnable()
    {
        P1Color = GameManager.Instance.ChosenStyle.XColor;
        P2Color = GameManager.Instance.ChosenStyle.OColor;

        GameWinner winner = BoardManager.Winner;
        float time = Timer.GetTime();

        switch (winner)
        {
            case GameWinner.X:
                EndText.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(P1Color)}>Player 1 (X)</color> won the game!";
                break;
            case GameWinner.O:
                EndText.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(P2Color)}>Player 2 (O)</color> won the game!";
                break;
            default:
                EndText.text = "Draw!";
                break;
        }

        TimeText.text = $"This game lasted {time} seconds!";
    }
}
