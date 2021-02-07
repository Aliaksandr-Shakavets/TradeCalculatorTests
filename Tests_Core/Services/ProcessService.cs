using System;
using System.Diagnostics;

namespace Tests_Core.Services
{
    public static class ProcessService
    {
        public static string executableFile = ApplicationSettings.TradeCalculatorExePath;
        private static readonly ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = executableFile,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        private static readonly Process process = new Process();

        public static string Start(string commandLineArguments)
        {
            if (commandLineArguments is null)
            {
                throw new ArgumentNullException(nameof(commandLineArguments));
            }

            processStartInfo.Arguments = commandLineArguments;
            process.StartInfo = processStartInfo;
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }

        public static void Close() => process.Close();

    }
}
