public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) :base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailString()
    {
        string status = IsComplete() ? "[X]" : "[-]";
        return $"{status} {GetName()} ({GetDescription()}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }
}