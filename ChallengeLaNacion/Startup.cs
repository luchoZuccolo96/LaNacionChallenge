using ChallengeLaNacion.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ChallengeLaNacion.Business.Interfaces;
using ChallengeLaNacion.Business.Services;
using ChallengeLaNacion.Interfaces;
using ChallengeLaNacion.Models;
using ChallengeLaNacion.Data.Repositories;

namespace ChallengeLaNacion
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
            services.AddResponseCompression();
            services.AddControllers();

            //Add policies as necessary.
            services.AddCors(options =>
                options.AddPolicy("PolicySPA", builder => builder.AllowAnyOrigin()
            ));

            //Swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
            });

            //MySql DATABASE
            string connectionString = Configuration.GetConnectionString("MyDbConnection");
            if (connectionString != null)
            {
                services.AddDbContext<DataContext>(options =>
                    options.UseMySql(
                        connectionString,
                        ServerVersion.AutoDetect(connectionString))
                );
            }
            else
            {
                throw new InvalidOperationException("Falta la configuracion para la base de datos.");
            }

            //Add SCOPES
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IRepository<Contact>, ContactRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

            //app.UseActiveDirectoryFederationServicesBearerAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Activate general policy
            app.UseCors("PolicySPA");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
