using System.Text;

namespace BigestWork.Loggers;

public class Logger : ILogger
{
    public string PathToLogFile { get; set; }

    public void SetLogWay(string way) {  
        PathToLogFile = way; 
    }

    public Logger()
    {
        SetLogWay("C:\\Users\\Ackepter\\Desktop\\Лабы\\ООП\\курсовая\\BigestWork\\BigestWork\\Files\\Log.txt");
    }

    public Logger(string pathToLogFile) : this()
    {
        SetLogWay(pathToLogFile);
    }
    
    public void Log(string message, LogType type)
    {
        if (CheckMessage(message)) return;

        string CurrentTime = GetCurrentTime();
        switch (type)
        {
            case LogType.Error:
                File.AppendAllText(PathToLogFile, $"ERROR({CurrentTime})  {message}\n", Encoding.UTF8);
                break;
            case LogType.Warning:
                File.AppendAllText(PathToLogFile, $"Warning({CurrentTime})  {message}\n", Encoding.UTF8);
                break;
            case LogType.Info:
                File.AppendAllText(PathToLogFile, $"Info({CurrentTime})  {message}\n", Encoding.UTF8);
                break;
        }
    }

    private string GetCurrentTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    private bool CheckMessage(string message)
    {
        return message is null || message.Length == 0;
    }
}
