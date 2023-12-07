using SistemaEscola.Aplicacao;
using SistemaEscola.Aplicacao.Usuarios.Servicos.Interface;
using SistemaEscola.Aplicacao.Usuarios.Servicos;
using SistemaEscola.Dominio.Repositorio.Interface;
using SistemaEscola.Dominio.Usuarios.Entidade;
using SistemaEscola.Infra;
using SistemaEscola.Infra.Repositorio;
using SistemaEscola.Dominio.Usuarios.Servicos;
using System.Reflection;
using SistemaEscola.Aplicacao.Boards.Servicos.Interface;
using SistemaEscola.Aplicacao.Boards.Servicos;
using SistemaEscola.Dominio.Baords.Servicos.Interface;
using SistemaEscola.Dominio.Baords.Servicos;
using SistemaEscola.Dominio.Baords.Entidade;
using SistemaEscola.Aplicacao.Colunas.Servicos.Interface;
using SistemaEscola.Aplicacao.Colunas.Servicos;
using SistemaEscola.Dominio.Colunas.Entidade;
using SistemaEscola.Aplicacao.Cartoes.Interface;
using SistemaEscola.Dominio.Cartoes.Entidade;
using SistemaEscola.Aplicacao.Cartoes;
using SistemaEscola.Aplicacao.Tarefas.Interface;
using SistemaEscola.Aplicacao.Tarefas;
using SistemaEscola.Dominio.Tarefas.Entidade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Injecao de dependencias - Usuarios
builder.Services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<IRepositorioGenerico<Usuario>, RepositorioGenerico<Usuario>>();
builder.Services.AddAutoMapper(typeof(UsuariosAppServico).GetTypeInfo().Assembly); // Vai passar na camada de aplicacao procurando quem herda o Profile


// Injecao de dependencias - Board
builder.Services.AddScoped<IBoardAppServico, BoardAppServico>();
builder.Services.AddScoped<IBoardServico, BoardServico>();
builder.Services.AddScoped<IRepositorioGenerico<Board>, RepositorioGenerico<Board>>();


// Injecao de dependencias - Colunas
builder.Services.AddScoped<IColunaAppServico, ColunaAppServico>();
builder.Services.AddScoped<IRepositorioGenerico<Coluna>, RepositorioGenerico<Coluna>>();

// Injecao de dependencias - Cartoes
builder.Services.AddScoped<ICartaoAppServico, CartaoAppServico>();
builder.Services.AddScoped<IRepositorioGenerico<Cartao>, RepositorioGenerico<Cartao>>();

// Injecao de dependencias - Tarefas
builder.Services.AddScoped<ITarefaAppServico, TarefaAppServico>();
builder.Services.AddScoped<IRepositorioGenerico<Tarefa>, RepositorioGenerico<Tarefa>>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Total", builder =>
    {
        builder.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();   
    });
});
var app = builder.Build();
app.UseCors("Total");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var dbCotext  = scope.ServiceProvider.GetRequiredService<AppDbContext>();
     dbCotext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
