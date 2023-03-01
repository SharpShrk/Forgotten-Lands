using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private GameObject _bodyParts;
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private SpeedImprove _speedImprove;

    private PlayerInput _input;
    private Animator _animator;
    private Vector2 _moveDirection;

    private float _halfPlayerWidth;
    private float _halfPlayerHeight;
    private float _startSpeed;

    private const string isMoving = nameof(isMoving);

    private void Awake()
    {
        _startSpeed = _moveSpeed;

        _animator = GetComponent<Animator>();

        _input = new PlayerInput();
        _input.Enable();

        _halfPlayerWidth = _body.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        _halfPlayerHeight = _body.transform.GetComponent<SpriteRenderer>().bounds.extents.y;

        PlaceInCenter();
    }

    private void Update()
    {
        _moveDirection = _input.Player.Move.ReadValue<Vector2>();

        StartMotionAnimation();
        RotateBody();
        ClampPlayerWithinScreen();
        Move(_moveDirection);        
    }

    public void TakeSpeedImprove()
    {
        _moveSpeed = _startSpeed + _speedImprove.SpeedBonus;
    }

    public void PlaceInCenter()
    {
        _player.transform.position = _spawnPoint.transform.position;
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.1)
            return;
        
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, direction.y, 0);
        transform.position += move * scaledMoveSpeed;
    }

    private void StartMotionAnimation()
    {
        if (_moveDirection.sqrMagnitude > 0.1)
        {
            _animator.SetBool(isMoving, true);
        }
        else
        {
            _animator.SetBool(isMoving, false);
        }
    }

    private void RotateBody()
    {
        if (_moveDirection.sqrMagnitude > 0.1)
        {
            if (_moveDirection.x < 0)
            {
                _bodyParts.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _bodyParts.transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }
    }

    private void ClampPlayerWithinScreen()
    {
        float screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, screenLeft + _halfPlayerWidth, screenRight - _halfPlayerWidth),
            Mathf.Clamp(transform.position.y, screenBottom + _halfPlayerHeight, screenTop - _halfPlayerHeight),
            0);
    }
}
