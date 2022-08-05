using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BackEnd
{
    public class Startup
    {
        public static readonly string CorsOrigins = "CorsOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "EngSpik";
                c.Version = "v1.0.0.";
                c.Title = "EngSpik";
            });
            services.AddDbContext<EngSpik.EngSpikDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("EngSpik"), new MySqlServerVersion(new System.Version(8, 0, 22)), mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)));
            services.AddCors(options =>
            {
                options.AddPolicy(CorsOrigins,
builder =>
{
    builder
       .AllowAnyOrigin()
       .AllowCredentials()
       .AllowAnyHeader()
       .AllowAnyMethod();
}
);
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
