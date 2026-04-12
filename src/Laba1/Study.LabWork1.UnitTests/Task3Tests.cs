using Study.LabWork1.Features;
namespace Study.LabWork1.UnitTests;

[TestFixture]
public class TestTask3
{
    [Test]
    public void GoRound_SingleNode_ShouldReturnOwnValue()
    {
        Node node = new("Дед");
        List<string> result = node.GoRound();
        Assert.That(result, Is.EqualTo(new List<string> { "Дед" }));
    }

    [Test]
    public void GoRound_WithChildren_ShouldReturnAllValues()
    {
        Node root = new("Дед");
        Node child1 = new("Батя");
        Node child2 = new("Дядя");
        root.Children.Add(child1);
        root.Children.Add(child2);
        List<string> result = root.GoRound();
        Assert.That(result, Is.EqualTo(new List<string> { "Дед", "Батя", "Дядя" }));
    }

    [Test]
    public void GoRound_DeepTree_ShouldReturnAllValues()
    {
        Node root = new("Дед");
        Node child1 = new("Батя");
        Node grandchild = new("Внучок");
        root.Children.Add(child1);
        child1.Children.Add(grandchild);
        List<string> result = root.GoRound();
        Assert.That(result, Is.EqualTo(new List<string> { "Дед", "Батя", "Внучок" }));
    }

    [Test]
    public void GoRound_EmptyChildren_ShouldReturnOnlyNode()
    {
        Node root = new("Дед");
        root.Children.Add(new Node("Батя"));
        List<string> result = root.GoRound();
        Assert.That(result, Is.EqualTo(new List<string> { "Дед", "Батя" }));
    }

    [Test]
    public void Constructor_ShouldSetValueCorrectly()
    {
        Node node = new("Тест");
        Assert.That(node.Value, Is.EqualTo("Тест"));
    }

    [Test]
    public void Constructor_ShouldInitializeEmptyChildren()
    {
        Node node = new("Тест");
        Assert.That(node.Children, Is.Empty);
    }
}
