using API.Models;
using backend.Models;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

//Configurar a política de CORS
builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Listar Aluno
app.MapGet("/alunos/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Aluno.Any())
    {
        return Results.Ok(ctx.Aluno.ToList());
    }
    return Results.NotFound("Nenhum aluno encontrada");
});

// Cadastrar Aluno
app.MapPost("/alunos/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Aluno aluno) =>
{
    var nomeExiste = ctx.Aluno.Any(a => a.Nome == aluno.Nome);
    var sobrenomeExiste = ctx.Aluno.Any(a => a.Sobrenome == aluno.Sobrenome);

    if (nomeExiste && sobrenomeExiste)
        return Results.BadRequest("O nome cadastrado já existe.");

    ctx.Aluno.Add(aluno);
    ctx.SaveChanges();

    return Results.Created("", aluno);
});

//Cadastrar IMC
app.MapPost("imc/cadastrar/{id}",  ([FromServices] AppDataContext ctx, int id, [FromBody] IMC request) =>
{
    var aluno = ctx.Aluno.Find(id);
    if (aluno is null)
    {
        return Results.NotFound("Aluno não encontrado");
    }

    var resultadoImc = request.Peso / (request.Altura * request.Altura);

    string classificacao = resultadoImc switch
    {
        < 18.5 => "Abaixo do peso",
        >= 18.5 and < 24.9 => "Peso normal",
        >= 25 and < 29.9 => "Sobrepeso",
        >= 30 => "Obesidade",
        _ => "Não classificado"
    };

    var imc = new IMC
    {
        AlunoId = id,
        Peso = request.Peso,
        Altura = request.Altura,
        resultadoImc = resultadoImc,
        classificacao = classificacao
    };

    ctx.IMC.Add(imc);
    ctx.SaveChanges();

    return Results.Created($"/imc/{imc.AlunoId}", imc);
});

// Listar IMC por aluno
app.MapGet("/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.IMC.Any())
    {
        return Results.Ok(ctx.IMC.ToList());
    }
    return Results.NotFound("Nenhum aluno encontrada");
});

//Alterar IMC
app.MapPost("imc/alterar", ([FromServices] AppDataContext ctx, [FromBody] int id) =>
{
    var aluno = ctx.Aluno.Find(id);
    if (aluno is null) {
        return Results.NotFound("Aluno não encontrado");
    }

    var imcs = ctx.IMC
        .Where(imc => imc.AlunoId == id)
        .Select(imc => new
        {
            imc.ImcID,
            imc.Peso,
            imc.Altura,
            imc.resultadoImc,
            imc.classificacao
        })
        .ToList();

    if (!imcs.Any()) {
        return Results.NotFound("Nenhum registro de IMC encontrado para este aluno");
    }

    return Results.Ok(imcs);
});



app.UseCors("Acesso Total");
app.Run();
