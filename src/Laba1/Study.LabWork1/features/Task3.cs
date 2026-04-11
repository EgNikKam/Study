namespace Study.LabWork1.Features;


///<summary>realisation Task3 class</summary>
public class Task3
{
    ///<summary>realisation Task3 class</summary>
    public void Exec()
    {
        Node root = new("Дед");
        Node child1 = new("Батя");
        Node child2 = new("Дядя");
        Node grandchild = new("Внучок");

        root.Children.Add(child1);
        root.Children.Add(child2);
        child1.Children.Add(grandchild);

        foreach (string val in root.GoRound())
            Console.WriteLine(val);
    }
}

public class Node
{
    public string Value { get; set; }
    public List<Node> Children { get; set; } = new();

    public Node(string value)
    {
        Value = value;
    }

    public List<string> GoRound()
    {
        List<string> result = new() { Value };
        foreach (Node child in Children)
        {
            result.AddRange(child.GoRound());
        }
        return result;
    }
}
