using TaskReturn.DataBase;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using TaskReturn.BusinessRepo;
using Serilog;
using Serilog.Formatting.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TaskDBContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

//Cors Policy

builder.Services.AddCors(options =>
                options.AddPolicy(

                    "CorsPolicy",

                    builder =>
                    {

                        _ = builder.WithOrigins("http://localhost:3000")

                                .AllowAnyMethod()

                                .AllowAnyHeader()

                                .AllowCredentials();

                    }));

// Add services to the container.
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .Enrich.FromLogContext()
   .WriteTo.File(new JsonFormatter(),"C:\\Logger_log\\Log-.log.txt")    
   .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddHostedService<TaskService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task", Version = "v1" });

});
//builder.Services.AddHostedService<TaskService>();
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}

//builder.Services.Configure(IApplicationBuilder app, IWebHostEnvironment Env);

//{

//    app.UseHostedService<BackgroundService>();

//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
