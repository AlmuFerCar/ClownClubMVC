using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Data;
using ClownClubMVC.Models.loggin;
using Microsoft.EntityFrameworkCore;
using ClownClubMVC.Business.Services;
using ClownClubMVC.Models.person;
using ClownClubMVC.WebApp.Controllers.StrategyFactoryPattern;
using ClownClubMVC.WebApp.Controllers.StrategyValidations;

var builder = WebApplication.CreateBuilder(args);
string proyectoRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));

// Configura DataDirectory para que apunte a la raíz del proyecto
AppDomain.CurrentDomain.SetData("DataDirectory", proyectoRaiz);

// Add services to the container.
builder.Services.AddControllersWithViews();
//DataBase
builder.Services.AddDbContext<DataDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
}
);

builder.Services.AddScoped<IGenericRepository<usersLoggin>, UserLogginRepository>();
builder.Services.AddScoped<IGenericRepository<passwordLoggin>, PasswordLogginRepository>();
builder.Services.AddScoped<IGenericRepository<person>, PersonRepository>();
builder.Services.AddScoped<IUsersLogginService, UsersLogginService>();
builder.Services.AddScoped<IPasswordLogginService, PasswordLogginService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ValidatePasswordPattern>();
builder.Services.AddScoped<StrategyFactory>();


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
    pattern: "{controller=Acces}/{action=Login}/{id?}");

app.Run();