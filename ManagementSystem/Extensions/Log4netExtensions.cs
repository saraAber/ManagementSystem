using log4net.Config;
using log4net;
using BLL.Service;

public static class Log4netExtensions
{
    public static void AddLog4net(this IServiceCollection services)
    {
        // This method loads the log4net configuration from the specified file.
        XmlConfigurator.Configure(new FileInfo("log4net.config"));
        
        // This allows you to use the same logger instance across the application.
        services.AddSingleton(LogManager.GetLogger(typeof(Program)));
    }
}