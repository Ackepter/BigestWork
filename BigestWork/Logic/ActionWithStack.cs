using BigestWork.Base;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace BigestWork.Logic;

public class ActionWithStack : IFunc
{
    private StackOnDoubleConnectedList<string> algorythm;
    
    private int MaxCollectionSize {  get; set; }
    private LinkedList<string> _list;

    public LinkedList<string> GetCopyOfInnerList()
    {
        return new LinkedList<string>(_list);
    }
    public ActionWithStack() => Configure(new Setting());

    public void Configure(Setting setting)
    {
        algorythm = (StackOnDoubleConnectedList<string>)setting.Algorithm;
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

        while (temp != null)
        {
            returnedString += temp.Value.ToString() + ":";
            temp = temp.Next;
        }

        return returnedString;
    }
    public string PrintStackBackward()
    {
        var temp = _list.Last;

        string returnedString = string.Empty;

        while (temp != null)
        {
            returnedString += temp.Value.ToString() + ":";
            temp = temp.Previous;
        }

        return returnedString;
    }

    public bool LoadFromFile(string path)
    {
        try
        {
            string info = File.ReadAllText(path);

            if (info != null && info.CompareTo(string.Empty) != 0)
            {
                string[] splitedInfo = info.Split(':');

                LinkedList<string> list = new LinkedList<string>();

                for (int i = 0; i < splitedInfo.Length - 1; i++)
                {
                    list.AddFirst(splitedInfo[i]);
                }

                algorythm.SetNewList(list);
                _list = (LinkedList<string>)algorythm.Collection;
            }
        }
        catch (Exception _)
        {
            return false;
        }

        return true;
    }

    public bool SaveInFile(string path)
    {
        try
        {
            File.WriteAllText(path, PrintStackBackward(), Encoding.UTF8);
        }
        catch (Exception _)
        {
            return false;
        }

        return true;
    }
}
