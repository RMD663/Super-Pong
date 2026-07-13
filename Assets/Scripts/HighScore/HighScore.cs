using System;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private string BasePrefKey => "67";
    
    private TextMeshProUGUI _winnerText;

    private void Awake()
    {
        _winnerText = GetComponent<TextMeshProUGUI>();
        ResetText();
    }

    private void ResetText()
    {
        if (_winnerText == null) return;
        
        String winnerName = PlayerPrefs.GetString(BasePrefKey, "Paddle");
        int winnerWins = PlayerPrefs.GetInt(winnerName, 0);
        _winnerText.text = $"HIGH-SCORE\n{winnerName} - {winnerWins} Wins";
    }

    private void OnEnable()
    {
        ResetButton.ResetPreferences += ResetText;
    }

    private void OnDisable()
    {
        ResetButton.ResetPreferences -= ResetText;
    }
    
}
