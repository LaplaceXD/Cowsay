using System.Diagnostics;

/// <summary>
/// Cowsay is a program that generates ASCII pictures of a cow with a message.
/// </summary>
static class Cow
{
    /// <summary>
    /// Generates a cow with a message.
    /// </summary>
    ///
    /// <param name="message">The message to display.</param>
    /// <returns>The ASCII picture of a cow with the message.</returns>
    ///
    /// <exception cref="Exception">If cowsay fails to generate the cow.</exception>
    public static string Say(string message)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "/usr/games/cowsay",
            RedirectStandardError = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };

        using var process = new Process
        {
            StartInfo = startInfo,
        };

        process.Start();
        process.StandardInput.WriteLine(message);
        process.StandardInput.Close();

        var output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            var error = process.StandardError.ReadToEnd();
            throw new Exception(error);
        }

        return output;
    }
}
