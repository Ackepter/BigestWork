using BigestWork.Base;
using System.Threading;

namespace BigestWork.Logic;

public class Setting
{
    public StackOnDoubleConnectedList<string> Algorithm { get; init; }

    public Setting(int timeOut, TimeSpan timeout) : this()
    {
        Algorithm = new StackOnDoubleConnectedList<string>(timeOut, timeout);
    }

    public Setting()
    {
        Algorithm = new StackOnDoubleConnectedList<string>();
    }
}
