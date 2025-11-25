using ChairElections.Models;
using ChairElections.Services;
using Microsoft.EntityFrameworkCore;
using ParliamentApi.Client;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Configure(context.Configuration.GetSection("Kestrel"));
});

var basePath = builder.Configuration["BasePath"];
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CommitteeContext>();
builder.Services.AddScoped<ChairNominationService>();
builder.Services.AddScoped<CommitteeService>();

builder.Services.AddHttpClient();

//builder.Services.AddScoped<MembersApiService>();

var app = builder.Build();


if (!string.IsNullOrEmpty(basePath))
{
    app.UsePathBase(basePath);
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CommitteeContext>();
    //db.Database.EnsureCreated();
    

    db.Database.Migrate(); 

}


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

app.Run();
