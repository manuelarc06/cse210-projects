public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent()
    {
        return _points;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailString()
    {
        return $"{_shortName}: {_description}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName}|{_description}|{_points}";
    }
}