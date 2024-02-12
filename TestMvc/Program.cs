using System.Configuration;
using TestMvc.Extentions;
using TestMvc.Options;

var builder = WebApplication.CreateBuilder(args);

var apiOptions = new ApiOptions();

builder.Configuration.GetSection(ApiOptions.Section)
    .Bind(apiOptions);

builder.Services.Configure<ApiOptions>(
    builder.Configuration.GetSection(ApiOptions.Section));

builder.Services.AddClientConfiguration(apiOptions);
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
