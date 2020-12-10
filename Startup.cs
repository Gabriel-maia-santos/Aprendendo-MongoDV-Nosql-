using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nyous.noSql.Contexts;
using Nyous.noSql.Interfaces.Repositories;
using Nyous.noSql.Repositories;

namespace Nyous.noSql {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            //Pegando as informações de appSettings
            services.Configure<NyousDatabaseSettings>(
                    Configuration.GetSection(nameof(NyousDatabaseSettings)));

            //Fazendo a injeção de dependencia
            services.AddSingleton<INyousDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<NyousDatabaseSettings>>().Value);
            services.AddSingleton<IEventoRepository, EventoRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
