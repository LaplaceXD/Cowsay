using System.ComponentModel;

try
{
    Console.Write("-> Tell me what you want to say: ");
    var message = Console.ReadLine();

    if (string.IsNullOrEmpty(message))
    {
        Console.WriteLine("error: message cannot be empty.");
        return;
    }

    var response = Cow.Say(message);
    Console.WriteLine(response);
}
catch (Win32Exception)
{
    Console.WriteLine("error: cowsay is not installed on this system.");
}
catch (Exception ex)
{
    Console.WriteLine($"error: {ex.Message}");
}
