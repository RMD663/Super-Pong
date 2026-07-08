using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public static event Action ResetGame;
    public static event Action ResetScore;
    public GameObject _playerPaddle;
    public GameObject _enemyPaddle;
    public GameObject _ball;

    public float PaddleSpawnPosition = 8f;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        _ball = Instantiate(_ball, new Vector3(0f, 0f, 0f), new Quaternion());
        _playerPaddle = Instantiate(_playerPaddle, new Vector3(-PaddleSpawnPosition, 0f, 0f), new Quaternion());
        _enemyPaddle = Instantiate(_enemyPaddle, new Vector3(PaddleSpawnPosition, 0f, 0f), new Quaternion());
        
        // PaddleAI enemyAI = _enemyPaddle.GetComponent<PaddleAI>();

        // if(enemyAI != null)
        // {
        //     enemyAI.ball = _ball;
        // }
    }

    void EndGame()
    {
        CallForReset();
        ResetScore?.Invoke();
    }

    void CallForReset()
    {
        ResetGame?.Invoke();
    }

    void OnEnable()
    {
        GoalManager.ResetBoard += CallForReset;
        ScoreManager.GameOver += EndGame;
    }

    void OnDisable()
    {
        GoalManager.ResetBoard -= CallForReset;
        ScoreManager.GameOver -= EndGame;
    }
}
