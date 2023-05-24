using Microsoft.Extensions.DependencyInjection;
using rcLogsBase;

namespace rcLogs_Log4Net
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogsBase, Logs>();
        }
    }
}
