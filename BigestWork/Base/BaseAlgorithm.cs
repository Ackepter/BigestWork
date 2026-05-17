namespace BigestWork.Base;

public abstract class BaseAlgorithm<T>
{
    public virtual string Name { get; init; } = string.Empty;
    public virtual string Description { get; init; } = string.Empty;


    public virtual IEnumerable<T> Collection { get; set; } = new LinkedList<T>();


    public virtual int MaxCollectionSize { get; init; } = int.MaxValue;

    public virtual TimeSpan Timeout { get; init; } = TimeSpan.FromMinutes(1);

    protected void Validate()
    {
        if (MaxCollectionSize <= 0) throw new ArgumentException("Максимальная длина коллекции должна быть больше 0");
        if (Timeout <= TimeSpan.Zero) throw new ArgumentException("Превышен лимит ожидания!");
    }
}
