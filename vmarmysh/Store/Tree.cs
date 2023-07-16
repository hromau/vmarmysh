using System.ComponentModel.DataAnnotations;

namespace vmarmysh.Store;

public class Tree
{
    [Key] public int Id { get; set; }
    public virtual List<Node> Nodes { get; set; } = new List<Node>();
    public string Name { get; set; }
}