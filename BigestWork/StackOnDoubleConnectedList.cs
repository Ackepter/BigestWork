namespace BigestWork;

public class StackOnDoubleConnectedList<T> : BaseAlgorithm<T> where T : class
{
    public override string Name { get; init; } = "StackOnDoubleConnectedList";

    public override string Description { get; init; } = string.Empty;

    protected override IEnumerable<T> Collection => _list;

    public override int MaxCollectionSize { get; init; } = int.MaxValue;

    public StackOnDoubleConnectedList() => Validate();

    private LinkedList<T> _list = new();

    public void Push(T Value)
    {
        if (_list.Count > MaxCollectionSize) return;

        _list.AddFirst(Value);
    }

    public T? Pop()
    {
        if(_list.Count == 0)
        {
            return null;
        }

        T buff = _list.First!.Value;
        _list.RemoveFirst();

        return buff;
    }

    public int Count => _list.Count;

    public bool IsEmpty => _list.Count == 0;

    public T? FindNodeForward(T Value)
    {
        var temp = _list.First;

        while (temp != null)
        {
            if (temp.Value == Value) return temp.Value;
            temp = temp.Next;
        }

        return null;
    }

    public T? FindNodeBackward(T Value)
    {
        var temp = _list.Last;

        while (temp != null)
        {
            if (temp.Value == Value) return temp.Value;
            temp = temp.Previous;
        }

        return null;
    }

    string PrintStackForward()
    {
        var temp = _list.First;

        string returnedString = string.Empty;

        int i = 0;
        while (temp != null)
        {
            returnedString += i.ToString() + ": " + temp.ToString();
            temp = temp.Next;
        }

        return returnedString;
    }

    string PrintStackBackward()
    {
        var temp = _list.Last;

        string returnedString = string.Empty;

        int i = 0;
        while (temp != null)
        {
            returnedString += i.ToString() + ": " + temp.ToString();
            temp = temp.Previous;
        }

        return returnedString;
    }
}
