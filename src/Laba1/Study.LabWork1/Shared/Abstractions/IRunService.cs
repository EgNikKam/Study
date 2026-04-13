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
    void RunTask1()
    {
        var p1 = new RgbaPixel(100, 50, 25, 0.5f);
        var p2 = new RgbaPixel(50, 50, 25, 0.3f);

        var sum = p1 + p2;
        Console.WriteLine($"Сложение: R:{sum.Red} G:{sum.Green} B:{sum.Blue} A:{sum.Alpha}");

        var diff = p1 - p2;
        Console.WriteLine($"Вычитание: R:{diff.Red} G:{diff.Green} B:{diff.Blue} A:{diff.Alpha}");

        var mult = p1 * 2;
        Console.WriteLine($"Умножение: R:{mult.Red} G:{mult.Green} B:{mult.Blue} A:{mult.Alpha}");

        Console.WriteLine($"Равны: {p1 == p2}");
        Console.WriteLine($"Не равны: {p1 != p2}");
    }

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
