using System;
using TMPro;
using UnityEngine;

public class LastWinnerText : MonoBehaviour
{
    private TextMeshProUGUI _winnerName;
    private String PrefKey => "67";
    
    void Start()
    {
        _winnerName = GetComponent<TextMeshProUGUI>();
        ResetText();
    }

    void ResetText()
    {
        _winnerName.text = $"LAST WINNER\n{PlayerPrefs.GetString(PrefKey, "Paddle")}";
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
