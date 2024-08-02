using System;

[Serializable]
public class Record : IComparable<Record>
{
    public string Name;
    public float Score;

    public Record(string name, float score)
    {
        Name = name;
        Score = score;
    }

    public int CompareTo(Record other)
    {
        return Score.CompareTo(other.Score);
    }
}