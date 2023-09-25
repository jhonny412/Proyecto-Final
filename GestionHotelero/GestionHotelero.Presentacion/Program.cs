using GestionHotelero.DataAccess;
using GestionHotelero.Entities.Configuration;
using GestionHotelero.Presentacion.Services;
using GestionHotelero.Repositories.Implementacion;
using GestionHotelero.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);
//Configurando la escritura del Log
const string formato = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:U}] - {Message}{NewLine}{Exception}";
var logger = new LoggerConfiguration()
    .WriteTo
    .Console(Serilog.Events.LogEventLevel.Information, outputTemplate: formato)
    .WriteTo.File("..\\Log.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
    outputTemplate: formato, rollingInterval: RollingInterval.Day)
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), new MSSqlServerSinkOptions
    {
        AutoCreateSqlDatabase = true,
        AutoCreateSqlTable = true,
        TableName = "LogStatus"
    }, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)

    .CreateLogger();

builder.Logging.AddSerilog(logger);

//Mapeamos los valores del Appsettings y obtenemos los valores de configuracion de correo
builder.Services.Configure<AppConfig>(builder.Configuration);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Estableciendo politicas de contrase�a
//Configuracion de ASP.NET Identity
builder.Services.AddDefaultIdentity<GestionHoteleroIdentityUser>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
//builder.Services.AddAutoMapper(
//        configuracion =>
//        {
//            configuracion.AddProfile<ClienteProfile>();
//        });

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEmailSender, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
    {
        // Aplica las migraciones de ser necesario
        dbContext.Database.Migrate();
    }
    //Aqui ejecutamos la creacion del usuario Admin y los roles por default
    await UserDataSeeder.Seed(scope.ServiceProvider);
}

app.Run();