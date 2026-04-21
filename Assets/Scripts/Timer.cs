using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI TimerText;

    private float _currentTime;
    private bool _isRunning = false;
    public bool IsRunning => _isRunning;
    private string _formattedTime;

    public static Action<float> OnGameEnd;

    private void Start()
    {
        _isRunning = true;

        UpdateTimerDisplay();

        BoardManager.OnWinGame += OnWinGame;
    }

    private void Update()
    {
        if (!_isRunning)
            return;

        _currentTime += Time.deltaTime;

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60f);
        int seconds = Mathf.FloorToInt(_currentTime % 60f);

        // Format: MM:SS (e.g., 05:30, 00:05)
        _formattedTime = TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PauseTimer()
    {
        _isRunning = false;
    }

    public void ResumeTimer()
    {
        _isRunning = true;
    }

    public void ResetTimer()
    {
        _currentTime = 0;
        _isRunning = true;
        UpdateTimerDisplay();
    }

    public void AddTime(float seconds)
    {
        _currentTime += seconds;
        UpdateTimerDisplay();
    }

    public void OverrideTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.FloorToInt(time % 60f);

        // Format: MM:SS (e.g., 05:30, 00:05)
        _formattedTime = TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public float GetRemainingTime()
    {
        return _currentTime;
    }

    public string GetFormattedTime()
    {
        return _formattedTime;
    }

    private void OnWinGame(GameWinner context, Vector2 context1, Vector2 context2) 
    {
        PauseTimer();

        OnGameEnd?.Invoke(_currentTime);
    }
}