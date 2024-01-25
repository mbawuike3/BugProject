using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using OneLog.Application.Behaviours;
using OneLog.DataAccess.ApplicationContext;
using OneLog.Domain.Entities;
using OneLog.MinimalApi.Extension;
using OneLog.Shared.Helpers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Adding swagger xml comments
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "OneLog v1", Version = "v1" });
    x.IncludeXmlComments(xmlPath);
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OneLogConnection"));
});
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IPasswordService, PasswordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ExtendBuilder();
app.UseHttpsRedirection();

//app.MapGet("/api/users/{id}", async (IMediator mediator, int id) =>
//{
//    var getUser = new GetUserByIdQuery { userId = id };
//    var user = await mediator.Send(getUser);
//    return Results.Ok(user);
//}). WithName("GetUserById");

//app.MapPost("/api/users", async (IMediator mediator, SignUpUserCommand command) =>
//{
//    await mediator.Send(command);
//    return Results.CreatedAtRoute("GetUserById", new { command.Id }, command);
//});

//app.MapPost("/api/users/(User-Login)", async (IMediator mediator, LoginUserCommand command) =>
//{
//    await mediator.Send(command);
//    return Results.Ok();
//});
app.Run();


