using MachineFinder.Api.Middleware;
using MachineFinder.Application;
using MachineFinder.Domain;
using MachineFinder.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();


//builder.Services.AddControllers();
builder.Services
    .AddControllers(options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
    })
    .AddNewtonsoftJson()
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    //})
    ;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });

    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1" });
});


builder.Services.AddSingleton<SessionStorage>();

builder.Services.AddInfrastructureDatabase(builder.Configuration);
builder.Services.AddApplicationMediatR();
builder.Services.AddInfrastructureServices(builder.Configuration);



var app = builder.Build();


app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwaggerUI();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Sample");
        // c.RoutePrefix = string.Empty; // UI en /
    });

    //builder.Services.AddEndpointsApiExplorer();
}

app.UseDeveloperExceptionPage();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());//put

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
