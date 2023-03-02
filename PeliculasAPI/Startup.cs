using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Servicios;

namespace PeliculasAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //aca van los servicios
        public void ConfigureServices(IServiceCollection services)
        {

        
            services.AddAutoMapper(typeof(Startup));    //AutoMapper
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>(); //Para guardar local los archivos
            services.AddHttpContextAccessor();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), 
            sqlServerOptions => sqlServerOptions.UseNetTopologySuite()
            ));
            services.AddControllers()
                .AddNewtonsoftJson();
            //services.AddEndpointsApiExplorer();




        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }



    }
}
