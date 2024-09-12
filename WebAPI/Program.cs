using Livro_de_Receita.modelo;
using Livro_de_Receita.repository.Interfaces;
using Livro_de_Receita.repository.Repositories;
using Livro_de_Receita.service.implemetations;
using Livro_de_Receita.service.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDifficulty, DifficultyRepository>();
builder.Services.AddScoped<IMeasure, MeasureRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IIngredient, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IRecipeIngredient, RecipeIngredientsRepository>();

builder.Services.AddScoped<IDifficultyService, DifficultyService>();
builder.Services.AddScoped<IMeasuresService, MeasureService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IIngredientsService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecipeIgredientsService, RecipeIngredientService>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "ChipsAhoy";
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.UseAuthorization();


app.MapControllers();

app.Run();
