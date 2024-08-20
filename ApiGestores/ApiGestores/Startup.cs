namespace ApiGestores
{
    using System.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    public  class Startup
    {
        public IConfiguration Configuration1 { get; }

        public Startup(IConfiguration configuration)
        {
           Configuration1 = configuration;
        }

        public static WebApplication inicializarApp (string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            configure(app);
            return app; 


        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<context.AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
        
            builder.Services.AddCors();
        }
         

        //public void ConfigureServices1(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    //services.AddDbContext<context.AppDbContext>(options => options.GetconectionString("conexion"));
           

        //}


        public static void configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            app.UseCors(options =>
            {
                options.WithOrigins("https://localhost:7194");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });  

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
