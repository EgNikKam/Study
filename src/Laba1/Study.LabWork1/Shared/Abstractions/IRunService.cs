using Study.LabWork1.Features;
namespace Study.LabWork1.Shared.Abstractions;

/// <summary>
/// Интерфейс для реализации заданий Л/Р
/// </summary>
public interface IRunService
{
    /// <summary>
    /// Запуск выполнения задания 1
    /// </summary>
    void RunTask1();

    /// <summary>
    /// Запуск выполнения задания 2
    /// </summary>
    void RunTask2();

    /// <summary>
    /// Запуск выполнения задания 3
    /// </summary>
    void RunTask3()
    {
        Node root = new("Дед");
        Node child1 = new("Батя");
        Node child2 = new("Дядя");
        Node grandchild1 = new("Внучок");
        Node grandchild2 = new("Племянник");

        root.Children.Add(child1);
        root.Children.Add(child2);
        child1.Children.Add(grandchild1);
        child2.Children.Add(grandchild2);

        foreach (string val in root.GoRound())
            Console.WriteLine(val);
    }
}
