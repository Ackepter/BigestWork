namespace BigestWork.Base;

public class StackOnDoubleConnectedList<T> : BaseAlgorithm<T> where T : class
{
    public override string Name { get; init; } = "StackOnDoubleConnectedList";

    public override string Description { get; init; } = "Представляет из себя стек, реализованный на двусвязном списке";
    public override int MaxCollectionSize { get; init; } = int.MaxValue;
    public int Count => _list.Count;
    public bool IsEmpty => _list.Count == 0;


    private LinkedList<T> _list = new();

    public void SetNewList(LinkedList<T> list)
    {
        if(list != null) _list = list;
    }
    public override IEnumerable<T> Collection => _list;


    public StackOnDoubleConnectedList() => Validate();

    public StackOnDoubleConnectedList(int maxSize)
    {
        MaxCollectionSize = maxSize;
    }

    public StackOnDoubleConnectedList(int maxSize, TimeSpan timeout) : this(maxSize)
    {
        if (maxSize <= 0) throw new ArgumentOutOfRangeException(nameof(maxSize));
        if (timeout < TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(timeout));

        Timeout = timeout;
    }

}
