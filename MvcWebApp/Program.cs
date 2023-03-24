using Infrastructure.Persistence.Extensions;
using MvcWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var persistenceSettings = builder.Configuration.GetSection("Persistence").Get<MPersistenceConfig>();

#region APP DI
if (persistenceSettings.UseSql== "Y")
{
    builder.Services.UseInfrastructurePersistence(builder.Configuration);
}
else
{
    builder.Services.UseInfrastructurePersistenceNoStorage(builder.Configuration);
}
builder.Services.UseCoreServices();

#endregion
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

if (builder.Configuration.GetValue<string>("Persistence:seed") == "Y")
{
    if (persistenceSettings.UseSql == "Y")
        app.Services.SeedCandidates();
    else
        app.Services.SeedCandidateNoStorage();

}

app.Run();
