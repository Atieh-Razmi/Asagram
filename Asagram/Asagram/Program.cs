using Application.Behaviers;
using Application.Interfaces;
using Asagram.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;




var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();


// Add services to the container.
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AsaGram.Presentiation.AssemblyReference).Assembly);

builder.Services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
builder.Services.ConfigureAuthService();
builder.Services.ConfigureUserService();
builder.Services.ConfigureRepositoryService();
builder.Services.ConfigureFileService();
builder.Services.ConfigureLeaveService();
builder.Services.ConfigureSwagger();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),
typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler();
if(app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ASAGram API v1");
});

app.MapControllers();

app.Run();
