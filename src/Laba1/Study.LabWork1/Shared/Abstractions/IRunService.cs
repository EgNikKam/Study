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
    void RunTask2()
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
    /// Запуск выполнения задания 3
    /// </summary>
    void RunTask3();
}
