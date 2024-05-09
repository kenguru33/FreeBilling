using System.Reflection;
using FreeBilling.Data;
using FreeBilling.Services;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.development.json", true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
    .AddCommandLine(args);

builder.Services.AddDbContext<BillingContext>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();

builder.Services.AddControllers();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailService, DevTimeEmailService>();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Allows us to serve files from wwwroot
app.UseStaticFiles();

// Allows us to serve index.html as the default webpage
app.UseDefaultFiles();



app.MapRazorPages();

//app.Run(async ctx =>
//{
//	await ctx.Response.WriteAsync("Welcome to FreeBilling");
//});

app.MapControllers();

app.Run();
