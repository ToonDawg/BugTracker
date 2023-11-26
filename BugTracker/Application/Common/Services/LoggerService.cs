namespace BugTracker.Application.Common.Services;

public interface ILoggerService
{
    void Info(string message);
    void Warn(string message);
    void Error(string message);
}

public class LoggerService : ILoggerService
{
    public void Error(string message)
    {
        Console.WriteLine(message);
    }

    public void Info(string message)
    {
        Console.WriteLine(message);
    }

    public void Warn(string message)
    {
        Console.WriteLine(message);
    }
}
