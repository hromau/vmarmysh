using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace vmarmysh.Store;

public class ExceptionLog 
{
    [Key] public int Id { get; set; }
    public string Type { get; set; }
    [JsonPropertyName("Id")] public string RequestId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
}