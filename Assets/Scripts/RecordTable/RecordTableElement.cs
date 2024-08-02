using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordTableElement : MonoBehaviour
{
    [SerializeField] private Image _cupImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void SetRecord(Sprite sprite, string name, float score)
    {
        _cupImage.sprite = sprite;
        _nameText.text = name;
        _scoreText.text = score.ToString("0.00");
    }
}
