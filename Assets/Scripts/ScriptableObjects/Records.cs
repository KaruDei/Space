using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Records", menuName = "Data/Records", order = 0)]
public class Records : ScriptableObject
{
    public List<Record> RecordList;
       
    public void AddRecord(string name, float score)
    {
        RecordList.Add(new Record (name, score));
        RecordList.Sort();
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString("Records", JsonUtility.ToJson(this));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Records"))
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Records"), this);
        else
            ClearRatingList();
    }

    public void ClearRatingList()
    {
        RecordList.Clear();
    }
}