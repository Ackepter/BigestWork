using BigestWork.Base;

namespace BigestWork.Logic;

public class Setting
{
    public BaseAlgorithm<string> Algorithm { get; init; }

    public Setting(int timeOut, TimeSpan timeout) : this()
    {
        Algorithm = new StackOnDoubleConnectedList<string>(timeOut, timeout);
    }

    public Setting()
    {
        Algorithm = new StackOnDoubleConnectedList<string>();
    }
}
