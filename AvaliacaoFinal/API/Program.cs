var builder = WebApplication.CreateBuilder(args);

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


app.UseCors("Acesso Total");
app.Run();
