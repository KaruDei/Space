using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 _touchDirection;
    private Vector2 _touchPosition;
    private bool _pressed;
    private float _rotatePositionZ;

    private Vector2 _tempPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
        _pressed = true;
    }

    private void FixedUpdate()
    {
        if (_pressed)
        {
            if (Input.touchCount > 0)
                _tempPosition = Input.GetTouch(Input.touchCount - 1).position;
            else
                _tempPosition = new(Input.mousePosition.x, Input.mousePosition.y);

            _touchDirection = _tempPosition - _touchPosition;
            _touchPosition = _tempPosition;
        }
        else
        {
            _touchDirection = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        _touchPosition = Vector2.zero;
        _tempPosition = Vector2.zero;
    }

    public void RotateDirectionZ(float num)
    {
        _rotatePositionZ = num;
    }

    public Vector3 GetRotateDirection()
    {
        return new Vector3(-_touchDirection.y, _touchDirection.x, _rotatePositionZ).normalized;
    }
}