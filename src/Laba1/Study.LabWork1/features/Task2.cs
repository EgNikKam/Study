namespace Study.LabWork1.Features;

///<summary>realisation Task1 class</summary>
class Task2
{
    public void Exec()
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
}

///<summary>realisation Task1 class</summary>
public interface IOrderRepo
{
    ///<summary>realisation Task1 class</summary>
    void SaveOrder(Order order);
    ///<summary>realisation Task1 class</summary>
    Order GetOrderById(string id);
    ///<summary>realisation Task1 class</summary>
    List<Order> GetOrders();
}

///<summary>realisation Task1 class</summary>
public class Order
{
    ///<summary>realisation Task1 class</summary>
    public string Id { get; set; }
    ///<summary>realisation Task1 class</summary>
    public string ClientName { get; set; }
    ///<summary>realisation Task1 class</summary>
    public string Garment { get; set; }
}

///<summary>realisation Clients class</summary>
public class Client
{
    private string _id;
    private string _name;
    private MemOrderSaver _memRepo;
    private CSVOrderRepo _csvRepo;

    ///<summary>rClient's id</summary>
    public string Id { get => _id; set => _id = value; }
    ///<summary>rClient's name</summary>
    public string Name { get => _name; set => _name = value; }

    private static string _generateID() => Guid.NewGuid().ToString();

    ///<summary>realisation Clients class constructor</summary>
    public Client(string name, MemOrderSaver memRepo, CSVOrderRepo csvRepo)
    {
        Id = _generateID();
        Name = name;
        _memRepo = memRepo;
        _csvRepo = csvRepo;
    }

    ///<summary>realisation request to DB </summary>
    public void Request(string garment)
    {
        Order order = new() { Id = Guid.NewGuid().ToString(), ClientName = Name, Garment = garment };
        _memRepo.SaveOrder(order);
        _csvRepo.SaveOrder(order);
    }
}

///<summary>realisation of csv adapter to make a request to DB </summary>
public class CSVOrderRepo : IOrderRepo
{
    private string _filepath;

    ///<summary>implementation SaveOrder method  CSVOrderRepo</summary>
    public void SaveOrder(Order order)
    {
        File.AppendAllText(_filepath, $"{order.Id},{order.ClientName},{order.Garment}\n");
    }

    ///<summary>implementation GetOrderById method  CSVOrderRepo</summary>
    public Order GetOrderById(string id)
    {
        if (id == null) return null;
        string[] lines = File.ReadAllLines(_filepath);
        string line = lines.FirstOrDefault(l => l.StartsWith(id));
        if (line == null) return null;
        string[] parts = line.Split(",");
        return new Order { Id = parts[0], ClientName = parts[1], Garment = parts[2] };
    }

    ///<summary>implementation GetOrders method  CSVOrderRepo</summary>
    public List<Order> GetOrders()
    {
        string[] lines = File.ReadAllLines(_filepath);
        List<Order> orders = new();
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split(",");
            orders.Add(new Order { Id = parts[0], ClientName = parts[1], Garment = parts[2] });
        }
        return orders;
    }

    ///<summary>constructor implementation</summary>
    public CSVOrderRepo(string filepath)
    {
        _filepath = filepath;
    }
}

///<summary>realisation of mem adapter to make a request to DB </summary>
public class MemOrderSaver : IOrderRepo
{
    ///<summary>init MemoryRepo</summary>
    protected List<Order> _orders = new();

    ///<summary>implementation SaveOrder method  MemOrderSaver</summary>
    public void SaveOrder(Order order)
    {
        _orders.Add(order);
    }

    ///<summary>implementation GetOrderById method  MemOrderSaver</summary>
    public Order GetOrderById(string id)
    {
        return _orders.Find(o => (o.Id == id));
    }

    ///<summary>implementation GetOrdersmethod  MemOrderSaver</summary>
    public List<Order> GetOrders()
    {
        return _orders;
    }
}
