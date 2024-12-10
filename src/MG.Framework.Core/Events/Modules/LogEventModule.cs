using MG.Framework.Core.Game;

namespace MG.Framework.Core.Events.Modules;

//Модуль логирования
//TODO: расширить и сделать гибкую систему логирования
public class LogEventModule
{
    // Модуль для примера
    public static void LogTime()
    {
        Console.WriteLine(DateTime.Now);
    }

    public static void LogEntities()
    {
        var entityInfos = GameManager.GetInstance()
                                     .GetEntities()
                                     .Select(e => (e.Id, e.UniqueName));

        foreach (var (Id, UniqueName) in entityInfos)
            Console.WriteLine($"ID: {Id} Name: {UniqueName}");
    }
}
