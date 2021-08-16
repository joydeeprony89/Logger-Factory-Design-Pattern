using System;

namespace Logger_Factory_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory consoleLoggerFactory = new ConsoleLoggerFactory(); // this can be register using the IoC container.
            var client = new Client(consoleLoggerFactory);
            client.ProcessLog("console logging !!");

            ILoggerFactory fileLoggerFactory = new FileLoggerFactory(); // this can be register using the IoC container.
            client = new Client(fileLoggerFactory);
            client.ProcessLog("file logging !!");

            ILoggerFactory dbLoggerFactory = new DbLoggerFactory(); // this can be register using the IoC container.
            client = new Client(dbLoggerFactory);
            client.ProcessLog("Db logging !!");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DbLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateFacotory();
    }

    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger CreateFacotory()
        {
            return new ConsoleLogger();
        }
    }

    public class FileLoggerFactory : ILoggerFactory
    {
        public ILogger CreateFacotory()
        {
            return new FileLogger();
        }
    }

    public class DbLoggerFactory : ILoggerFactory
    {
        public ILogger CreateFacotory()
        {
            return new DbLogger();
        }
    }

    public class Client
    {
        readonly ILoggerFactory loggerFactory;

        public Client(ILoggerFactory _loggerFactory)
        {
            loggerFactory = _loggerFactory;
        }

        public void ProcessLog(string message)
        {
            ILogger logger = loggerFactory.CreateFacotory();
            logger.Log(message);
        }
    }
}
