using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{

    [Header("Movement Variables")]
    [SerializeField] private float _topSpeed;
    [SerializeField] private float _accSpeed;
    [SerializeField] private float _deccSpeed;

    private Rigidbody2D _rb2D;
    private Transform objectTransform;

    private float _targetSpeed;
    private float _speedDiff;
    private float _accRate;

    private bool isPlayerInRadius;

    private Transform playerTransform;

    private float playerDist_X;
    private float _moveInput;

    private float _movement;

    // Start is called before the first frame update
    private void Awake()
    {
        objectTransform = gameObject.transform;
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = true;
            playerTransform = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRadius = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRadius)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        playerDist_X = playerTransform.position.x - objectTransform.position.x;

        _moveInput = Mathf.Clamp(playerDist_X, -1, 1);

        _targetSpeed = _moveInput * _topSpeed;
        _speedDiff = _targetSpeed - _rb2D.velocity.x;
        _accRate = (Mathf.Abs(_targetSpeed) > 0.01f) ? _accSpeed : _deccSpeed;
        _movement = (Mathf.Abs(_speedDiff) * _accRate) * Mathf.Sign(_speedDiff);

        _rb2D.AddForce(Vector2.right * _movement);
    }
}
