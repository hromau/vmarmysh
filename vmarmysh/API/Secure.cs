namespace vmarmysh.API;

public class Secure : Exception
{
    public Secure(string message) : base(message)
    {
    }
}