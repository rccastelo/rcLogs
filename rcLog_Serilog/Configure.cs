using Microsoft.Extensions.DependencyInjection;
using rcLog_Base;

namespace rcLog_Serilog
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogBase, Log>();
        }
    }
}
