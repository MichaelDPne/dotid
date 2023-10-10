using dotidapi.Context;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace dotidapi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DotIdDb");

            services.AddDbContext<DotIdContext>(options => options.UseSqlServer(connection));

        }
    }
}
