namespace vmarmysh.API;

public record ExceptionResponse
{
    public string Type { get; set; }
    public string Id { get; set; }
    public string Data { get; set; }
}