using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private float _time;
    private bool _active;

    private void Start()
    {
        _active = true;
    }

    private void FixedUpdate()
    {
        if (_active)
            _time += Time.fixedDeltaTime;

        _timerText.text = _time.ToString("0.00");
    }

    public void TimerStart()
    {
        _active = true;
    }

    public void TimerStop()
    {
        _time = 0f;
        _active = false;
    }

    public void TimerPause()
    {
        _active = false;
    }

    public float GetScore() 
    {
        return _time;
    }
}