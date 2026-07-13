using UnityEngine;

public class Ball : MonoBehaviour
{
    public float InitialForce = 10f;
    public float BounceForce = 1f;
    private Vector2 _initialDirection;
    private Rigidbody2D _rb;
    private bool _gameOver = false;
 
    private void Start()
    {
        Reset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 currentDirection = _rb.linearVelocity.normalized;

        float currentSpeed = _rb.linearVelocity.magnitude;

        float newSpeed = currentSpeed + BounceForce;

        _rb.linearVelocity = currentDirection * newSpeed;
    }

    private void ApplyRandomForce(){

        float initialX = Random.value > 0.5f ? 1.0f : -1.0f;
        float initialY = Random.value > 0.5f ? 1.0f : -1.0f;

        _initialDirection = new Vector2(initialX, initialY).normalized;
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = _initialDirection * InitialForce;
    }

    private void Reset()
    {
        if(_gameOver) return;
        
        ApplyRandomForce();
        transform.position = Vector2.zero;
        
    }
    private void EndGame()
    {
        _gameOver = true;
        _rb.linearVelocity = Vector2.zero;
    }

    private void OnEnable()
    {
        GameManager.ResetGame += Reset;
        ScoreManager.GameOver += EndGame;
    }

    private void OnDisable()
    {
        GameManager.ResetGame -= Reset;
        ScoreManager.GameOver -= EndGame;
    }

}
