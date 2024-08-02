using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _direction;

    private void FixedUpdate()
    {
        foreach (Transform elem in transform)
        {
            elem.RotateAround(transform.position, _direction, _rotationSpeed);
            elem.Rotate(_direction, _rotationSpeed);
        }
    }
}