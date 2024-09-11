using System.ComponentModel;

try
{
    using Cowsay cowsay = new();

    Console.Write("-> Tell me what you want to say: ");
    string? message = Console.ReadLine();

    if (string.IsNullOrEmpty(message))
    {
        Console.WriteLine("error: message cannot be empty.");
        return;
    }

    string cowsayResponse = cowsay.Say(message);
    Console.WriteLine(cowsayResponse);
}
catch (Win32Exception)
{
    Console.WriteLine("error: cowsay is not installed on this system.");
}
catch (Exception ex)
{
    Console.WriteLine($"error: {ex.Message}");
}
