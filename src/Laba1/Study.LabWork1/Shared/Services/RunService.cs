using Study.LabWork1.Shared.Abstractions;
using Study.LabWork1.Features;
namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        new Task1().Exec();
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {
        new Task2().Exec();
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
