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
        var p1 = new RgbaPixel(100, 50, 25, 0.5f);
        var p2 = new RgbaPixel(50, 50, 25, 0.3f);

        RgbaPixel sum = p1 + p2;
        Console.WriteLine($"Сложение: R:{sum.Red} G:{sum.Green} B:{sum.Blue} A:{sum.Alpha}");

        RgbaPixel diff = p1 - p2;
        Console.WriteLine($"Вычитание: R:{diff.Red} G:{diff.Green} B:{diff.Blue} A:{diff.Alpha}");

        RgbaPixel mult = p1 * 2;
        Console.WriteLine($"Умножение: R:{mult.Red} G:{mult.Green} B:{mult.Blue} A:{mult.Alpha}");

        Console.WriteLine($"Равны: {p1 == p2}");
        Console.WriteLine($"Не равны: {p1 != p2}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {
        MemOrderSaver memRepo = new();
        CSVOrderRepo csvRepo = new("orders.csv");
        Client client = new("Вася", memRepo, csvRepo);

        client.Request("пуховик женский");
        client.Request("пуховик мужской");

        Console.WriteLine("=== Memory ===");
        foreach (Order order in memRepo.GetOrders())
            Console.WriteLine($"Id: {order.Id}, Client: {order.ClientName}, Garment: {order.Garment}");

        Console.WriteLine("=== CSV ===");
        foreach (Order order in csvRepo.GetOrders())
            Console.WriteLine($"Id: {order.Id}, Client: {order.ClientName}, Garment: {order.Garment}");
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3()
    {
        Node root = new("Дед");
        Node child1 = new("Батя");
        Node child2 = new("Дядя");
        Node grandchild = new("Внучок");

        root.Children.Add(child1);
        root.Children.Add(child2);
        child1.Children.Add(grandchild);

        foreach (string val in root.GoRound())
        {
            Console.WriteLine(val);
        }
    }
}
