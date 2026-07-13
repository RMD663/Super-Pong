using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    
    public static event Action ResetGame;
    public static event Action ResetScore;
    
    [Header("Activate Multiplayer Mode")]
    public bool IsMultiplayer;
    [Header("Object References")]
    public GameObject _playerPaddle;
    public GameObject _enemyPaddle;
    public GameObject _ball;

    [Header("Paddle Data")]
    public PaddleData paddleOneData;
    public PaddleData paddleTwoData;

    [Header("Spawn Position")]
    public float PaddleSpawnPosition = 8f;
    

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        _ball = Instantiate(_ball, new Vector3(0f, 0f, 0f), new Quaternion());
        _playerPaddle = Instantiate(_playerPaddle, new Vector3(-PaddleSpawnPosition, 0f, 0f), Quaternion.identity);
        _enemyPaddle = Instantiate(_enemyPaddle, new Vector3(PaddleSpawnPosition, 0f, 0f), Quaternion.identity);
        
        MovementComponent enemyMovementComponent = _enemyPaddle.GetComponent<MovementComponent>();
        MovementComponent playerMovementComponent = _playerPaddle.GetComponent<MovementComponent>();

        playerMovementComponent.player = paddleOneData.Player;
        enemyMovementComponent.player = paddleTwoData.Player;
        
        if(!IsMultiplayer){
            
            enemyMovementComponent.enabled = false;

            PaddleAI enemyAI = _enemyPaddle.AddComponent<PaddleAI>();

            if(enemyAI != null)
            {
                enemyAI.ball = _ball;
            }
        }

        SpriteRenderer playerMesh = _playerPaddle.GetComponentInChildren<SpriteRenderer>();
        SpriteRenderer enemyMesh = _enemyPaddle.GetComponentInChildren<SpriteRenderer>();

        
        playerMesh.color = paddleOneData.PlayerColor;
        enemyMesh.color = paddleTwoData.PlayerColor;

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
