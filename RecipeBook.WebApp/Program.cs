using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.repository.Repositories;
using Livro_de_Receita.service.implemetations;
using Livro_de_Receita.service.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Livro_de_Receita.modelo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDifficulty, DifficultyRepository>();
builder.Services.AddScoped<IMeasure, MeasureRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IIngredient, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IRecipeIngredient, RecipeIngredientsRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IFavorite, FavoriteRepository>();


builder.Services.AddScoped<IDifficultyService, DifficultyService>();
builder.Services.AddScoped<IMeasuresService, MeasureService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IIngredientsService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecipeIgredientsService, RecipeIngredientService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();




builder.Services.AddSession(options =>
{
    options.Cookie.Name = "ChipsAhoy";
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.IsEssential = true;


});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(options =>
   {
       options.Cookie.Name = "ChipsAhoy";
       options.LogoutPath = "/Index";
       options.LoginPath = "/Account/Login"; // Página de login
       options.AccessDeniedPath = "/Account/AccessDenied";
   });

builder.Services.AddAuthorization();





builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
