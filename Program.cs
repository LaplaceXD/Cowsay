using System.ComponentModel;

try
{
    Cowsay cowsay = new();

    cowsay.OutputDataReceived += (_, e) =>
    {
        if (!String.IsNullOrEmpty(e.Data))
        {
            Console.WriteLine(e.Data);
        }
    };

    cowsay.ErrorDataReceived += (sender, e) =>
    {
        if (!String.IsNullOrEmpty(e.Data))
        {
            Console.WriteLine($"error: {e.Data}");
        }
    };

    Console.Write("-> Tell me what you want to say: ");
    string? message = Console.ReadLine();

    if (string.IsNullOrEmpty(message))
    {
        Console.WriteLine("error: message cannot be empty.");
        return;
    }

    cowsay.Say(message);
}
catch (Win32Exception)
{
    Console.WriteLine("error: cowsay is not installed on this system.");
}
catch (Exception ex)
{
    Console.WriteLine($"error: {ex.Message}");
}
