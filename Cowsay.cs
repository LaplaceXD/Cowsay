using System.Diagnostics;

class Cowsay : IDisposable
{
    private Process _process;
    public event DataReceivedEventHandler? OutputDataReceived;
    public event DataReceivedEventHandler? ErrorDataReceived;

    public Cowsay()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "/usr/games/cowsay",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        _process = new()
        {
            StartInfo = startInfo,
        };

        _process.OutputDataReceived += (sender, e) => OutputDataReceived?.Invoke(sender, e);
        _process.ErrorDataReceived += (sender, e) => ErrorDataReceived?.Invoke(sender, e);

        _process.Start();
    }

    public void Say(string message)
    {
        _process.StandardInput.WriteLine(message);
        _process.StandardInput.Close();

        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
        _process.WaitForExit();
    }

    public void Dispose()
    {
        _process.Dispose();
    }
}
