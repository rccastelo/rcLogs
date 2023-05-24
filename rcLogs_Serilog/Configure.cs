using Microsoft.Extensions.DependencyInjection;
using rcLogsBase;

namespace rcLogs_Serilog
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogsBase, Logs>();
        }
    }
}
