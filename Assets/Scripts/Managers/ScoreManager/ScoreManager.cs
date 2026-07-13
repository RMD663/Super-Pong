using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action GameOver;
    public static event Action<String> Winner;
    
    private int _playerScore = 0;
    private int _enemyScore = 0;

    private String _winnerName = "Player";
    
    private TextMeshProUGUI _textComponent;
    public GameObject ScoreText;

    [Header("Paddle Data")]
    public PaddleData PaddleOneData;
    public PaddleData PaddleTwoData;
    
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
            if (_playerScore > 2)
            {
                _winnerName = PaddleOneData.PaddleName;
            }
            else if (_enemyScore > 2)
            {
                _winnerName = PaddleTwoData.PaddleName;
            }
            GameOver?.Invoke();
            Winner?.Invoke(_winnerName);
        }
    }
    void UpdateScore()
    {
        _textComponent.text = $"{_playerScore} - {_enemyScore}";
    }

    void OnEnable()
    {
        GoalManager.MarkedGoal += OnScore;
        GameManager.ResetScore += EngGame;
    }

    void OnDisable()
    {
        GoalManager.MarkedGoal -= OnScore;
        GameManager.ResetScore -= EngGame;
    }

    void EngGame()
    {
        UpdateScore();
    }
}
