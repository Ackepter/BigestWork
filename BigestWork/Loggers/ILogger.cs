namespace BigestWork.Loggers;

public interface ILogger
{
    string PathToLogFile { get; set; }

    public void Log(string message, LogType type);
}
