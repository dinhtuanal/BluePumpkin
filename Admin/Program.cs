using Clients.Implements;
using Clients.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Auth/Login";
    option.LogoutPath = "/Auth/LogOut";
    option.AccessDeniedPath = "/Error/Index";
});
builder.Services.AddTransient<IUserClient, UserClient>();
builder.Services.AddTransient<IRoleClient, RoleClient>();
builder.Services.AddTransient<IEventClient, EventClient>();

builder.Services.AddTransient<IQuestionClient, QuestionClient>();
builder.Services.AddTransient<IPrizeClient, PrizeClient>();
builder.Services.AddTransient<IJoinEventClient, JoinEventClient>();
builder.Services.AddTransient<IPrizeDistributionClient, PrizeDistributionClient>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
