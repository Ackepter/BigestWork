using BigestWork.Base;

namespace BigestWork.Logic;

public class ActionWithAlgorythm : IFunc
{
    private int MaxCollectionSize {  get; set; }
    private LinkedList<string> _list;

    public ActionWithAlgorythm() => Configure(new Setting());

    public void Configure(Setting setting)
    {
        var algorythm = setting.Algorithm;
        _list = (LinkedList<string>)algorythm.Collection;

        MaxCollectionSize = algorythm.MaxCollectionSize;
    }

    public void Push(string Value)
    {
        if (_list.Count > MaxCollectionSize) return;

        _list.AddFirst(Value);
    }
    public string? Pop()
    {
        if (_list.Count == 0)
        {
            return null;
        }

        string buff = _list.First!.Value;
        _list.RemoveFirst();

        return buff;
    }

    public string? FindNodeForward(string Value)
    {
        var temp = _list.First;

        while (temp != null)
        {
            if (temp.Value == Value) return temp.Value;
            temp = temp.Next;
        }

        return null;
    }
    public string? FindNodeBackward(string Value)
    {
        var temp = _list.Last;

        while (temp != null)
        {
            if (temp.Value == Value) return temp.Value;
            temp = temp.Previous;
        }

        return null;
    }

    public string PrintStackForward()
    {
        var temp = _list.First;

        string returnedString = string.Empty;

        int i = 0;
        while (temp != null)
        {
            returnedString += (i++).ToString() + ": " + temp.ToString();
            temp = temp.Next;
        }

        return returnedString;
    }
    public string PrintStackBackward()
    {
        var temp = _list.Last;

        string returnedString = string.Empty;

        int i = 0;
        while (temp != null)
        {
            returnedString += (i++).ToString() + ": " + temp.ToString();
            temp = temp.Previous;
        }

        return returnedString;
    }

    public void LoadFromFile()
    {
        throw new NotImplementedException();
    }

    public void SaveInFile()
    {
        throw new NotImplementedException();
    }
}
