using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction move;

    [Header("Player")]
    [SerializeField] private GameObject _player;

    private Rigidbody2D _rb2D;

    [SerializeField] private GroundCheck groundCheck;
    private SpriteRenderer _spriteRenderer;

    [Header("Movement Parameters")]
    [SerializeField] private float _topSpeed;
    [SerializeField] private float _accSpeed;
    [SerializeField] private float _deccSpeed;

    private float _targetSpeed;
    private float _speedDiff;
    private float _accRate;

    private float _movement;

    [Header("Jumping Parameters")]
    [SerializeField] private float _jumpVel;

    [Header("Gravity Multiplier")]
    [SerializeField] private float _gravityMultipier = 1.5f;
    [SerializeField] private float maxGravity;

    private float _gravity;
    private bool isGrounded;

    private float _moveInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];

        playerInput.actions["Jump"].performed += Jump;

        _rb2D = _player.GetComponent<Rigidbody2D>();
        _spriteRenderer = _player.GetComponent<SpriteRenderer>();
        _gravity = _rb2D.gravityScale;
    }

    private void FixedUpdate()
    {
        _moveInput = move.ReadValue<float>();
        Moving();
        BetterJump();
    }

    private void Update()
    {
        isGrounded = groundCheck.IsGrounded();

        if ((_moveInput > 0 && !_spriteRenderer.flipX) || (_moveInput < 0 && _spriteRenderer.flipX))
        {
            Flip();
            Debug.Log("flipped");
        }
    }

    private void Moving()
    {
        _targetSpeed = _moveInput * _topSpeed;
        _speedDiff = _targetSpeed - _rb2D.velocity.x;
        _accRate = (Mathf.Abs(_targetSpeed) > 0.01f) ? _accSpeed : _deccSpeed;
        _movement = (Mathf.Abs(_speedDiff) * _accRate) * Mathf.Sign(_speedDiff);

        _rb2D.AddForce(Vector2.right * _movement);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpVel);
        }
    }

    private void BetterJump()
    {
        if (_rb2D.velocity.y < -1f)
        {
            _rb2D.gravityScale *= _gravityMultipier;
        }
        else
        {
            _rb2D.gravityScale = _gravity;
        }

        _rb2D.gravityScale = Mathf.Clamp(_rb2D.gravityScale, 0, maxGravity);
    }
    private void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private void OnDisable()
    {
        playerInput.actions["Jump"].performed -= Jump;
    }
}


