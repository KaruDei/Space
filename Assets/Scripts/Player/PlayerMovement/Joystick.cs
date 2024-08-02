using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform _marker;
    [SerializeField] private float _joystickRadius;

    private Vector2 _direction;
    private Vector2 _startPosition;
    private Vector2 _offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _offset = eventData.position - _startPosition;
        _offset = Vector2.ClampMagnitude(_offset, _joystickRadius);
        _marker.anchoredPosition = _offset;
        _direction = _offset.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _direction = Vector3.zero;
        _offset = Vector2.zero;
        _startPosition = Vector2.zero;
        _marker.anchoredPosition = Vector2.zero;
    }

    public Vector3 GetDirection()
    {
        return new Vector3(_direction.x, 0, _direction.y);
    }
}