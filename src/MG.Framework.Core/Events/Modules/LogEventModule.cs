using MG.Framework.Core.Game;

namespace MG.Framework.Core.Events.Modules;

public class LogEventModule
{
    // Модуль для примера
    public static void LogTime(GameManager gameManager)
    {
        Console.WriteLine(DateTime.Now);
    }
}
