using GerenciadorPedidos.Domain.Interfaces.Repositorios;
using GerenciadorPedidos.Domain.Interfaces.Servicos;
using GerenciadorPedidos.Domain.Services;
using GerenciadorPedidos.Infra.Data.Context;
using GerenciadorPedidos.Infra.Data.Repositorios;
using GerenciadorPedidos.Infra.Transacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace GerenciadorPedidos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();
            services.AddScoped<GerenciadorPedidosContext, GerenciadorPedidosContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IServicoCategoriaProduto, ServicoCategoriaProduto>();
            services.AddTransient<IRepositorioCategoriaProduto, RepositorioCategoriaProduto>();
            services.AddTransient<IServicoProduto, ServicoProduto>();
            services.AddTransient<IRepositorioProduto, RepositorioProduto>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Gerenciador de Pedidos", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseSwagger();
            app.UseSwaggerUI(item =>
            {
                item.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciador de Pedidos - V1");
            });
        }
    }
}
