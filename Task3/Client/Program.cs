namespace Client;

internal static class Program
{
    public static void Main(string[] args)
    {
        var client = new Task3.Client("127.0.0.1", 12000);
    }
}