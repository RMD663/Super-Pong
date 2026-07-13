using System;
using TMPro;
using UnityEngine;

public class WinnerText : MonoBehaviour
{
    private string BasePrefKey => "67";

    
    private String _winnerName;
    
    private TextMeshProUGUI _inputText;
    
    private void Awake()
    {
        _inputText = GetComponent<TextMeshProUGUI>();
    }

    void WinnerTextUpdate(String winner)
    {
        _inputText.text = $"{winner} WON";
        
        PlayerPrefs.SetString(BasePrefKey, winner);
        
        int winStreak = PlayerPrefs.GetInt(winner, 0);
        
        winStreak += 1;
        
        PlayerPrefs.SetInt(winner, winStreak);
        
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        ScoreManager.Winner += WinnerTextUpdate;
    }
    private void OnDisable()
    {
        ScoreManager.Winner -= WinnerTextUpdate;
    }
}
