using BigestWork.Base;

namespace BigestWork.Logic;

public class ActionWithAlgorythm : IFunc
{
    StackOnDoubleConnectedList<string>? _algorythm;
    Setting? _setting;

    public void Configure(Setting setting)
    {
        if(setting is not null)
        {
            _setting = setting;
            _algorythm = _setting.Algorithm;
        }
    }

    public void Push(string value)
    {
        if (_algorythm is not null && value is not null && value != "")
        {
            _algorythm.Push(value);
        }
    }

    public string? Pop()
    {
        if (_algorythm is not null)
        {
            return _algorythm.Pop();
        }

        return null;
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
