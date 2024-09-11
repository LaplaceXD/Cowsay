using System.Diagnostics;

class Cowsay : IDisposable
{
    private Process _process;

    public Cowsay()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "/usr/games/cowsay",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        _process = new()
        {
            StartInfo = startInfo
        };

        _process.Start();
    }

    public string Say(string message)
    {
        _process.StandardInput.WriteLine(message);
        _process.StandardInput.Close();

        string cowsayResponse = _process.StandardOutput.ReadToEnd();
        _process.WaitForExit();

        return cowsayResponse;
    }

    public void Dispose()
    {
        _process.Dispose();
    }
}
