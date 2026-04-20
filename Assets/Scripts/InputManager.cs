using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CurrentTurn WhoseTurnIsIt;

    public static Action<CurrentTurn> OnBeginTurn;

    private void Start()
    {
        //X goes first (player 1)
        WhoseTurnIsIt = CurrentTurn.PLAYER1;

        OnBeginTurn?.Invoke(WhoseTurnIsIt);

        GameTile.OnClickTile += NextTurn;
    }

    private void OnDestroy()
    {
        GameTile.OnClickTile -= NextTurn;
    }

    public void NextTurn() 
    {
        WhoseTurnIsIt = WhoseTurnIsIt.Equals(CurrentTurn.PLAYER1) ? CurrentTurn.PLAYER2 : CurrentTurn.PLAYER1;
        OnBeginTurn?.Invoke(WhoseTurnIsIt);
    }
}
//Player1 - X, Player2- O
public enum CurrentTurn 
{
    PLAYER1, PLAYER2
}
