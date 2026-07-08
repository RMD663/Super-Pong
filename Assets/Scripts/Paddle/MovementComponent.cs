using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    public enum PLAYER {P1, P2};

    [Header("Select Player")]
    public PLAYER player;
    [Header("Paddle Movement Stats")]
    public float Speed = 9f;
    public float moveBorders = 3.9f;

    [Header("Player Input")]
    public InputActionAsset inputActions;
    private InputAction _verticalInput;
    private float _inputAxis = 0f;
    private Vector2 _initialPosition;
    private Rigidbody2D _rb;

    void Awake()
    {
        _initialPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(_initialPosition);

        if (player == PLAYER.P1)
        {
            _verticalInput = inputActions.FindAction("VerticalAxis");
        }
        
        if (player == PLAYER.P2)
        {
            _verticalInput = inputActions.FindAction("VerticalAxisP2");
        }
    }

    

    void FixedUpdate()
    {   
        OnVerticalAxis();
        float currentY = _rb.position.y;
        if(currentY >= moveBorders && _inputAxis >= 0f) _inputAxis = 0f;
        if(currentY <= -moveBorders && _inputAxis <= 0f) _inputAxis = 0f;

        _rb.linearVelocity = new Vector2(0f, _inputAxis * Speed);

    }

    void OnVerticalAxis()
    {
        _inputAxis = _verticalInput.ReadValue<float>();
    }
    void OnEnable()
    {
        GameManager.ResetGame += Reset;
    }

    void OnDisable()
    {
        GameManager.ResetGame -= Reset;
    }

    void Reset()
    {
        transform.position = _initialPosition;
    }
}
