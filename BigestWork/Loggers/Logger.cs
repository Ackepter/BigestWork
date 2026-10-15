using System.Text;

namespace BigestWork.Loggers;

public static class Logger
{
    public static string PathToLogFile { get; set; } = "C:\\Users\\Ackepter\\Desktop\\УЧЁБА\\Прошлое\\ООП\\курсовая\\BigestWork\\BigestWork\\Log.txt";

    public static void SetLogWay(string way) {  
        PathToLogFile = way; 
    }
    
    public static void Log(string message, LogType type)
    {
        if (CheckMessage(message)) return;

        if (!File.Exists(PathToLogFile))
        {
            File.Create(PathToLogFile).Close();
        }

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

    private static string GetCurrentTime() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    private static bool CheckMessage(string message)
    {
        return message is null || message.Length == 0;
    }
}
