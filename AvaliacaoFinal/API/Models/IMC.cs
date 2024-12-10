using System;

namespace API.Models;

public class IMC
{
    public int ImcID {get; set;}
    public int AlunoId {get; set;}
    public double Altura {get; set;}
    public double Peso {get; set;}
    public double resultadoImc {get; set;}
    public string? classificacao {get; set;}
}
