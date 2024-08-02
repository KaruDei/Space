using UnityEngine;

public class Border : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameEvents _gameEvents;
    [SerializeField] private GameObject _warningText;

    [Header("Time")]
    [SerializeField] private float _maxTime;

    private float _time;
    private bool _timerActive;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timerActive = false;
            _time = 0f;
            _warningText.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _timerActive = true;
            _warningText.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (_timerActive)
        {
            if (_time + Time.fixedDeltaTime < _maxTime)
                _time += Time.fixedDeltaTime;
            else
            {
                _gameEvents.GameOver($"You lost contact with the SaveShip!");
                _timerActive = false;
            }
        }
    }
}