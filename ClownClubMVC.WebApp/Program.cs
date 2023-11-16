using ClownClubMVC.Data.Repositories;
using ClownClubMVC.Data;
using ClownClubMVC.Models.loggin;
using Microsoft.EntityFrameworkCore;
using ClownClubMVC.Models.person;
using ClownClubMVC.WebApp.Controllers.StrategyFactoryPattern;
using ClownClubMVC.WebApp.Controllers.StrategyValidations;
using ClownClubMVC.Models.content;
using ClownClubMVC.Business.Services.Interfaces.Content;
using ClownClubMVC.Business.Services.Interfaces.Login;
using ClownClubMVC.Business.Services.Interfaces.Person;
using ClownClubMVC.Business.Services.Content;
using ClownClubMVC.Business.Services.Login;
using ClownClubMVC.Business.Services.Person;
using ClownClubMVC.Data.Repositories.Content;
using ClownClubMVC.Data.Repositories.Login;
using ClownClubMVC.Data.Repositories.Person;

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
builder.Services.AddScoped<IGenericRepository<content>, ContentRepository>();
builder.Services.AddScoped<IGenericRepository<film>, FilmRepository>();
builder.Services.AddScoped<IGenericRepository<serie>, SerieRepository>();
builder.Services.AddScoped<IGenericRepository<podcast>, PodcastRepository>();
builder.Services.AddScoped<IGenericRepository<tvProgram>, TvProgramRepository>();
builder.Services.AddScoped<IUsersLogginService, UsersLogginService>();
builder.Services.AddScoped<IPasswordLogginService, PasswordLogginService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<IPodcastService, PodcastService>();
builder.Services.AddScoped<ITvProgramService, TvProgramService>();
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