using TMPro;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private Records _records;
    [SerializeField] private Timer _timer;

    [Header("EndGameWindow")]
    [SerializeField] private RectTransform _endGameWindow;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private TextMeshProUGUI _scoreText; 

    private bool _game;

    private void Start()
    {
        _game = true;
    }

    public void GameOver(string text)
    {
        _game = false;
        _endGameWindow.gameObject.SetActive(true);
        _messageText.text = text;
        _scoreText.gameObject.SetActive(false);
    }

    public void GameWin()
    {
        _game = false;
        
        if (PlayerPrefs.HasKey("PlayerName"))
            _records.AddRecord(PlayerPrefs.GetString("PlayerName"), _timer.GetScore());
        else
            _records.AddRecord("Player", _timer.GetScore());

        _endGameWindow.gameObject.SetActive(true);
        _messageText.text = "You saved!";
        _scoreText.gameObject.SetActive(true);
        _scoreText.text = _timer.GetScore().ToString("0.00");
    }

    public bool GameStatus()
    {
        return _game;
    }
}