using FelipeAzevedo.TesteXP.Business;
using FelipeAzevedo.TesteXP.Repositories.Cliente;
using FelipeAzevedo.TesteXP.Repositories.Endereco;
using FelipeAzevedo.TesteXP.Resources.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FelipeAzevedo.TesteXP
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
            services.AddDbContext<XpContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetSection("ConnectionStrings:SqlServer").Value,
                    builder =>
                    {
                        builder.EnableRetryOnFailure();
                    });
            });
            
            services.AddTransient<ICadastroBusiness, CadastroBusiness>();
            
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "teste-tecnico-xp",
                        Version = "v1",
                        Description = "Teste Técnico XP"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
