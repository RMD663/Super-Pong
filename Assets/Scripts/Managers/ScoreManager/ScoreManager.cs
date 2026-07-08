using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static event Action GameOver;
    private int _playerScore = 0;
    private int _enemyScore = 0;

    private TextMeshProUGUI _textComponent;
    public GameObject ScoreText;

    void Awake()
    {
        if(ScoreText != null)
        {
            _textComponent = ScoreText.GetComponent<TextMeshProUGUI>();
        }

        UpdateScore();
    }

    void OnScore(GoalManager.TEAM team)
    {
        switch (team)
        {
            case GoalManager.TEAM.PLAYER:
                _playerScore += 1;
                UpdateScore();
                break;
            case GoalManager.TEAM.AI:
                _enemyScore += 1;
                UpdateScore();
                break;
            default:
                Debug.Log("INVALID TEAM!");
                break;
        }

        if (_playerScore > 2 || _enemyScore > 2)
        {
            GameOver?.Invoke();
        }
    }
    void UpdateScore()
    {
        _textComponent.text = $"{_playerScore} - {_enemyScore}";
    }

    void OnEnable()
    {
        GoalManager.MarkedGoal += OnScore;
        GameManager.ResetScore += ResetScore;
    }

    void OnDisable()
    {
        GoalManager.MarkedGoal -= OnScore;
        GameManager.ResetScore -= ResetScore;
    }

    void ResetScore()
    {
        _playerScore = 0;
        _enemyScore = 0;
        UpdateScore();
    }
}
