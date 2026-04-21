using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI TotalTimesPlayed;
    public TextMeshProUGUI P1Wins;
    public TextMeshProUGUI P2Wins;
    public TextMeshProUGUI Draws;
    public TextMeshProUGUI AverageGameTime;

    private void OnEnable()
    {
        TotalTimesPlayed.text = Stats.Instance.TimesPlayed.ToString();
        P1Wins.text = Stats.Instance.Player1Wins.ToString();
        P2Wins.text = Stats.Instance.Player2Wins.ToString();
        Draws.text = Stats.Instance.Draws.ToString();
        AverageGameTime.text = Stats.Instance.AverageGameTime.ToString();
    }
}
