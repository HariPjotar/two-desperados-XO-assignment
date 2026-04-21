using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats Instance { get; private set; }

    private const string PLAYER1_WINS = "P1Wins";
    public int Player1Wins;

    private const string PLAYER2_WINS = "P2Wins";
    public int Player2Wins;

    private const string DRAWS = "Draws";
    public int Draws;

    private const string TIMES_PLAYED = "TimesPlayed";
    public int TimesPlayed;

    private const string TOTAL_GAME_TIME = "TotalGameTime";
    public float TotalGameTime;

    public float AverageGameTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadStats();
    }

    private void Start()
    {
        BoardManager.OnWinGame += OnWinGame;
        Timer.OnGameEnd += AddTime;
    }

    private void OnDestroy()
    {
        BoardManager.OnWinGame -= OnWinGame;
        Timer.OnGameEnd -= AddTime;
    }

    private void LoadStats() 
    {
        Player1Wins = PlayerPrefs.GetInt(PLAYER1_WINS, 0);
        Player2Wins = PlayerPrefs.GetInt(PLAYER2_WINS, 0);
        Draws = PlayerPrefs.GetInt(DRAWS, 0);
        TimesPlayed = PlayerPrefs.GetInt(TIMES_PLAYED, 0);
        TotalGameTime = PlayerPrefs.GetFloat(TOTAL_GAME_TIME, 0f);

        if(TimesPlayed != 0)
            AverageGameTime = TotalGameTime / TimesPlayed;
        else
            AverageGameTime = 0f;
    }

    private void IncrementP1Wins() 
    {
        int wins = PlayerPrefs.GetInt(PLAYER1_WINS);
        PlayerPrefs.SetInt(PLAYER1_WINS, wins + 1);
    }

    private void IncrementP2Wins()
    {
        int wins = PlayerPrefs.GetInt(PLAYER2_WINS);
        PlayerPrefs.SetInt(PLAYER2_WINS, wins + 1);
    }

    private void IncrementDraws()
    {
        int draws = PlayerPrefs.GetInt(DRAWS);
        PlayerPrefs.SetInt(DRAWS, draws + 1);
    }

    private void IncrementGamesPlayed()
    {
        int gamesPlayed = PlayerPrefs.GetInt(TIMES_PLAYED);
        PlayerPrefs.SetInt(TIMES_PLAYED, gamesPlayed + 1);
    }

    private void OnWinGame(GameWinner result, Vector2 context, Vector2 context2) 
    {
        IncrementGamesPlayed();

        if (result.Equals(GameWinner.X))
            IncrementP1Wins();

        if (result.Equals(GameWinner.O))
            IncrementP2Wins();

        if (result.Equals(GameWinner.DRAW))
            IncrementDraws();
    }
    private void AddTime(float time) 
    {
        float totalTime = PlayerPrefs.GetFloat(TOTAL_GAME_TIME, 0);
        PlayerPrefs.SetFloat(TOTAL_GAME_TIME, totalTime + time);
    }
}
