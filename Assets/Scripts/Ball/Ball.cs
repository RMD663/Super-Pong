using UnityEngine;

public class Ball : MonoBehaviour
{
    public float InitialForce = 10f;
    public float BounceForce = 1f;
    private Vector2 _initialDirection;
    private Rigidbody2D _rb;
 
    void Start()
    {
        Reset();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 currentDirection = _rb.linearVelocity.normalized;

        float currentSpeed = _rb.linearVelocity.magnitude;

        float newSpeed = currentSpeed + BounceForce;

        _rb.linearVelocity = currentDirection * newSpeed;
    }

    void ApplyRandomForce(){

        float initialX = Random.value > 0.5f ? 1.0f : -1.0f;
        float initialY = Random.value > 0.5f ? 1.0f : -1.0f;

        _initialDirection = new Vector2(initialX, initialY).normalized;
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = _initialDirection * InitialForce;
    }

    void Reset()
    {
       ApplyRandomForce();
       transform.position = Vector2.zero;
    }

    void OnEnable()
    {
        GameManager.ResetGame += Reset;
    }

    void OnDisable()
    {
        GameManager.ResetGame -= Reset;
    }

}
