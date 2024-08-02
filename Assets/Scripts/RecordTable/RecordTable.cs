using System.Collections.Generic;
using UnityEngine;

public class RecordTable : MonoBehaviour
{
    [SerializeField] private Records _records;
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Sprite> _cupSprites;

    private void Start()
    {
        _records.Load();
        SetRecords();
    }

    public void SetRecords()
    {
        ClearRecords();
        if (_records.RecordList.Count > 0)
        {
            for (int i = 0; i < _records.RecordList.Count; i++)
            {
                GameObject record = Instantiate(_prefab, _content);
                switch (i)
                {
                    case 0:
                        record.GetComponent<RecordTableElement>().SetRecord(_cupSprites[0], _records.RecordList[i].Name, _records.RecordList[i].Score);
                        break;
                    case 1:
                        record.GetComponent<RecordTableElement>().SetRecord(_cupSprites[1], _records.RecordList[i].Name, _records.RecordList[i].Score);
                        break;
                    case 2:
                        record.GetComponent<RecordTableElement>().SetRecord(_cupSprites[2], _records.RecordList[i].Name, _records.RecordList[i].Score);
                        break;
                    default:
                        record.GetComponent<RecordTableElement>().SetRecord(_cupSprites[3], _records.RecordList[i].Name, _records.RecordList[i].Score);
                        break;
                }
                _content.sizeDelta =new Vector2(_content.sizeDelta.x, (120 * _content.childCount) + (25 * (_content.childCount - 1)));
            }
        }
        else
        {
            Debug.Log("No records!");
            _content.sizeDelta =new Vector2(_content.sizeDelta.x, 483);
        }
    }

    public void ClearRecords()
    {
        if (_content.childCount > 0)
            foreach (Transform elem in _content)
                Destroy(elem.gameObject);
    }
}