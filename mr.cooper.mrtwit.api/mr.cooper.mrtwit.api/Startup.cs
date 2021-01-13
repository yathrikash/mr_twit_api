using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using mr.cooper.mrtwit.logger.Concrete;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models.Configuration;
using System.Linq;

namespace mr.cooper.mrtwit.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddResponseCompression();

            if (!services.Any(x => x.ServiceType == typeof(IMrLogger)))
            {
                services.AddSingleton(LogProvider.GetLogger());
            }

            //TODO: Needs to be refactored, for now it is consuming time to read dictionary from appsettings. if time permits do this
            services.AddSingleton<AppConfig>(x => new AppConfig
            {
                MongoConnectionName = new MongoConnection
                {
                    ConnectionString = Configuration.GetSection("MongoConnection").GetSection("ConnectionString").Value,
                    DataBaseName = Configuration.GetSection("MongoConnection").GetSection("DataBaseName").Value,

                    CollectionNames = new CollectionDictionary
                    {
                        ["ProfileDbCollectionName"] = Configuration.GetSection("MongoConnection").GetSection("CollectionNames").GetSection("ProfileDbCollectionName").Value,
                        ["UserDbCollectionName"] = Configuration.GetSection("MongoConnection").GetSection("CollectionNames").GetSection("UserDbCollectionName").Value
                    }
                }
            });

            mrtwit.services.ServiceRegistry.AddEssentialDependencies(services);

            services.AddResponseCaching();

            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(MessageLogHandler))
            }
            )
                .AddJsonOptions(jo =>

                {
                }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptionsMonitor<AppConfig> config)
        {
            app.UseHealthChecks("/health");

            config.OnChange((AppConfig changedConfig, string name) =>
            {

            }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseResponseCaching();

            //app.UseMvc();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
