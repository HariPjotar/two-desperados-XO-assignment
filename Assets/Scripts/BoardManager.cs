using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public List<GameTile> Tiles;
    public Vector2 TilePadding = new Vector2(100f, 100f);
    public Image[] BoardLines;

    [Space]

    public GameObject EndScreen;
    public AudioClip DrawLineAudio;

    [Space]

    public GameWinner Winner;

    [Space]

    public float EndScreenDelay;

    private static readonly int[][] WinningLines = new int[][]
    {
        new int[] { 0, 1, 2 }, // top row
        new int[] { 3, 4, 5 }, // middle row
        new int[] { 6, 7, 8 }, // bottom row
        new int[] { 0, 3, 6 }, // left column
        new int[] { 1, 4, 7 }, // middle column
        new int[] { 2, 5, 8 }, // right column
        new int[] { 0, 4, 8 }, // diagonal
        new int[] { 2, 4, 6 }, // anti-diagonal
    };

    public static Action<GameWinner, Vector2, Vector2> OnWinGame;

    private void Start()
    {
        GameTile.OnClickTile += CheckGameState;

        DrawBoardLines();
    }

    private void OnDestroy()
    {
        GameTile.OnClickTile -= CheckGameState;
    }

    private void CheckGameState()
    {
        List<GameTile> tiles = Tiles;

        //Winner checking
        foreach (int[] line in WinningLines)
        {
            TileValue a = tiles[line[0]].Value;
            TileValue b = tiles[line[1]].Value;
            TileValue c = tiles[line[2]].Value;

            if (a != TileValue.NONE && a == b && a == c)
            {
                Vector2 tile1Pos = tiles[line[0]].transform.position;
                Vector2 tile2Pos = tiles[line[2]].transform.position;

                GameWinner w = a == TileValue.X ? GameWinner.X : GameWinner.O;
                Winner = w;

                OnWinGame?.Invoke(w, tile1Pos, tile2Pos);
                StartCoroutine(ShowEndScreenCoroutine(EndScreenDelay));

                return;
            }
        }

        bool isDraw = tiles.TrueForAll(tile => tile.Value != TileValue.NONE);
        if (isDraw)
        {
            //vec2.zero because the context doesn't matter when it's a draw
            Winner = GameWinner.DRAW;
            OnWinGame?.Invoke(GameWinner.DRAW, Vector2.zero + Vector2.left * 50, Vector2.zero + Vector2.left * 50);
            StartCoroutine(ShowEndScreenCoroutine(EndScreenDelay));
        }
    }

    private void DrawBoardLines() 
    {
        float i = 0;
        float j = 0;
        float k = 0;
        float l = 0;

        DOTween.To(() => i, x => i = x, 1f, 0.65f).OnStart(() => 
        {
            AudioManager.Instance.PlaySFX(DrawLineAudio, true);
        }).OnUpdate(() => 
        {
            BoardLines[0].fillAmount = i;
        });

        DOTween.To(() => j, x => j = x, 1f, 0.65f).OnStart(() =>
        {
            AudioManager.Instance.PlaySFX(DrawLineAudio, true);
        }).OnUpdate(() =>
        {
            BoardLines[1].fillAmount = j;
        }).SetDelay(0.2f);

        DOTween.To(() => k, x => k = x, 1f, 0.65f).OnStart(() =>
        {
            AudioManager.Instance.PlaySFX(DrawLineAudio, true);
        }).OnUpdate(() =>
        {
            BoardLines[2].fillAmount = k;
        });

        DOTween.To(() => l, x => l= x, 1f, 0.65f).OnStart(() =>
        {
            AudioManager.Instance.PlaySFX(DrawLineAudio, true);
        }).OnUpdate(() =>
        {
            BoardLines[3].fillAmount = l;
        });
    }

    private IEnumerator ShowEndScreenCoroutine(float delay) 
    {
        yield return new WaitForSeconds(delay);

        EndScreen.SetActive(true);
    }
}
public enum GameWinner 
{
    X, O, DRAW
}
