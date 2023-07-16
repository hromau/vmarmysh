using System.ComponentModel.DataAnnotations;

namespace vmarmysh.Store;

public class Node
{
    [Key] public int Id { get; set; }
    public int TreeId { get; set; }
    public int? ParentNodeId { get; set; }
    public virtual Tree Tree { get; set; }
    public string Name { get; set; }
}