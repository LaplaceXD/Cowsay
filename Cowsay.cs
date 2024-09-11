using System.Diagnostics;

/// <summary>
/// Cowsay is a program that generates ASCII pictures of a cow with a message.
/// </summary>
class Cowsay : IDisposable
{
    private Process _process;

    /// <summary>
    /// Event handler for receiving data from Cowsay.
    /// </summary>
    public event DataReceivedEventHandler? OutputDataReceived;

    /// <summary>
    /// Event handler for receiving error data from Cowsay.
    /// </summary>
    public event DataReceivedEventHandler? ErrorDataReceived;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cowsay"/> class.
    /// </summary>
    ///
    /// <exception cref="Win32Exception">The Cowsay program is not installed.</exception>
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

    /// <summary>
    /// Say a message with Cowsay, which generates an ASCII picture of a cow with the message.
    /// </summary>
    ///
    /// <param name="message">The message to say.</param>
    public void Say(string message)
    {
        _process.StandardInput.WriteLine(message);
        _process.StandardInput.Close();

        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
        _process.WaitForExit();
    }

    /// <summary>
    /// Releases all resources used by the <see cref="Cowsay"/>.
    /// </summary>
    public void Dispose()
    {
        _process.Dispose();
    }
}
