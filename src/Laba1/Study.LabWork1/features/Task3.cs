namespace Study.LabWork1.Features;


///<summary>realisation Task3 class</summary>


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
