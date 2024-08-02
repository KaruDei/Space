using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _accelerationDistance = 50f;
    [SerializeField] private float _detectionDistance = 2f;
    [SerializeField] private float _playerDetectionDistance = 3f;

    private Vector3 _direction;

    private void FixedUpdate()
    {
        if (_gameEvents.GameStatus())
        {
            _direction = (_target.position - transform.position).normalized;
            transform.LookAt(_target);

            if (!Physics.Raycast(transform.position, _direction, _detectionDistance))
            {
                if (Vector3.Distance(transform.position, _target.position) > _accelerationDistance)
                    transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * _acceleration * Time.fixedDeltaTime);
                else
                    transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);
            }
            else
            {
                _direction = Vector3.Cross(_direction, Vector3.up).normalized;
                transform.position += _direction * _speed * Time.fixedDeltaTime;
            }

            if (Vector3.Distance(transform.position, _target.position) < _playerDetectionDistance)
            {
                _gameEvents.GameOver("You were caught by aliens!");
            }
        }
    }
}