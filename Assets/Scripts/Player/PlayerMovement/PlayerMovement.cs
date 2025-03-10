using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private TouchPanel _touchPanel;

    [Header("Speeds")]
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _maxRotateSpeed;

    private Vector3 _moveDirection;
    private Vector3 _rotateDirection;
    
    private float _afterburnerSpeed;

    public bool IsMoving = false;
    public bool IsAfterburner = false;

    private void FixedUpdate()
    {
        _moveDirection = _joystick.GetDirection();
        _rotateDirection = _touchPanel.GetRotateDirection();
        Move();
        Rotate();
    }

    private void Move()
    {
        if (_moveDirection.magnitude != 0)
        {
            IsMoving = true;
            _rb.AddForce(transform.TransformDirection(_moveDirection * (_maxMoveSpeed + _afterburnerSpeed) * Time.fixedDeltaTime), ForceMode.Acceleration);
        }
        else
            IsMoving = false;
    }

    private void Rotate()
    {
        if (_rotateDirection.magnitude != 0)
            _rb.AddTorque(transform.TransformDirection(_rotateDirection * _maxRotateSpeed * Time.fixedDeltaTime), ForceMode.Acceleration);
    }

    public void RemoveVelocity()
    {
        _rb.velocity = Vector3.zero;
    }

    public void Afterburner(bool status) 
    {
        if (status) 
        {
            IsAfterburner = true;
            _afterburnerSpeed = _maxMoveSpeed;
        }
        else
        {
            IsAfterburner = false;
            _afterburnerSpeed = 0f;
        }
    }
}