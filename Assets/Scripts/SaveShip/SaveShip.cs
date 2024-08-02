using UnityEngine;

public class SaveShip : MonoBehaviour
{
    [SerializeField] private GameEvents _gameEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (_gameEvents.GameStatus()) 
        {
            _gameEvents.GameWin();
        }
    }
}