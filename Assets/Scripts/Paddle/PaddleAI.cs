using NUnit.Framework;
using UnityEditor.Callbacks;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    [HideInInspector]
    public GameObject ball;

    public float Speed = 5.0f;
    private Transform _ballTransform;
    private Rigidbody2D _rb;

    public float moveBorders = 7f;
    private float _inputAxis = 0f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ball != null && _ballTransform == null) _ballTransform = ball.transform;

        if (_ballTransform == null) return;


        if (_ballTransform.position.y > transform.position.y + 0.2f)
        {
            _inputAxis = 1f;
        }
        else if(_ballTransform.position.y < transform.position.y - 0.2f)
        {
            _inputAxis = -1f;
        }
        else
        {
            _inputAxis = 0f;
        }

        float currentY = _rb.position.y;

        if(currentY >= moveBorders && _inputAxis > 0f)
        {
            _inputAxis = 0f;
        }
        if(currentY <= -moveBorders && _inputAxis < 0f)
        {
            _inputAxis = 0f;
        }

        _rb.linearVelocity = new Vector2(0f, _inputAxis * Speed);
    }
}
