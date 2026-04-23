using TMPro;
using UnityEngine;

public class PlayerTurnCounterUI : MonoBehaviour
{
    public TextMeshProUGUI P1TurnCounter;
    public TextMeshProUGUI P2TurnCounter;

    private Color _p1Color;
    private Color _p2Color;

    private int _p1Moves;
    private int _p2Moves;

    private void Start()
    {
        _p1Color = GameManager.Instance.ChosenStyle.XColor;
        _p2Color = GameManager.Instance.ChosenStyle.OColor;

        _p1Moves = 0;
        P1TurnCounter.text = _p1Moves.ToString();
        P1TurnCounter.color = _p1Color;

        _p2Moves = 0;
        P2TurnCounter.text = _p2Moves.ToString();
        P2TurnCounter.color = _p2Color;

        GameTile.OnPlaceSymbol += UpdateCounters;
    }

    private void OnDestroy()
    {
        GameTile.OnPlaceSymbol -= UpdateCounters;
    }

    private void UpdateCounters(TileValue symbol) 
    {
        if (symbol.Equals(TileValue.X))
            _p1Moves++;

        if (symbol.Equals(TileValue.O))
            _p2Moves++;

        P1TurnCounter.text = _p1Moves.ToString();
        P2TurnCounter.text = _p2Moves.ToString();
    }
}
