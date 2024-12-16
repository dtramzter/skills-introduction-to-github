using Microsoft.EntityFrameworkCore;
using PST.Components;
using PST.Model;
using QuestPDF.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();


builder.Services.AddSingleton<variables_glovales>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//ESTO SE AGREGA para QuestPDF ****

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//+++++++++++++++++++++++++++++++++++++++++++++
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
//"http://*:5004"
app.Run();
