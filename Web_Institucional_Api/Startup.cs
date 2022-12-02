using Web_Institucional_Api.Services;

namespace Web_Institucional_Api
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
            services.AddControllers();
            services.AddSwaggerGen();

            // configure DI for application services
            services.AddScoped<ICarruselService, CarruselService>();
            services.AddScoped<IAccionesPrincipalesService, AccionesPrincipalesService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IAutoridadesService, AutoridadesServece>();
            services.AddScoped<IPaginasService, PaginasService>();
            services.AddScoped<ISeccionesService, SeccionesService>();
            services.AddScoped<IInstitucionalService, InstitucionalService>();
            services.AddScoped<IRedesSocialesService, RedesSocialesService>();
            services.AddScoped<IArchivosContenidoService, ArchivosContenidoService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<INoticiaPrincipalService, NoticiaPrincipalService>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<ICardsService, CardService>();
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
