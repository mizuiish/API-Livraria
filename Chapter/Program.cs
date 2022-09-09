using Chapter.Contexts;
using Chapter.Interfaces;
using Chapter.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//sempre colocar o cors nesse local do código para que funcione. options é uma expressão lambda para configurar
//o cors. os argumentos dentro do AddPolicy também são expressões lambdas. Não esquecer de dar using no app
//acima do authorization
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});

builder.Services.AddScoped<SqlContext, SqlContext>();

builder.Services.AddTransient<LivroRepository, LivroRepository>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
