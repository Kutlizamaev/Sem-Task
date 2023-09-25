namespace CarFleet.HOST.Logs
{
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo[] logsDirectory = currentDirectory.GetDirectories("Logs");
            string path;

            if (logsDirectory.Length != 0)
            {
                path = Path.Combine(logsDirectory.First().FullName, "logs.txt");
            }
            else
            {
                currentDirectory.CreateSubdirectory("Logs");
                path = Path.Combine(currentDirectory.GetDirectories("Logs").First().FullName, "logs.txt");
            }

            return new FileLogger(path);
        }

        public void Dispose()
        {
        }
    }
}
