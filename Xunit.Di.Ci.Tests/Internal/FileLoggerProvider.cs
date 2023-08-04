using Microsoft.Extensions.Logging;

namespace Xunit.Di.Ci.Tests
{
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}
