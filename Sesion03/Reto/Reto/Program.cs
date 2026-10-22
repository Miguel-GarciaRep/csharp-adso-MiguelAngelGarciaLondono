using System;
using System.Linq;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string[] nombres_reglas =
{
    "Mínimo 8 caracteres",
    "Una mayúscula",
    "Una minúscula",
    "Un número",
    "Un carácter especial",
    "Sin espacios"
};

while (true)
{
    Console.Write("Contraseña: ");
    string contraseña = Console.ReadLine() ?? "";

    (bool[] reglas, int puntaje, string nivel) = EvaluarContraseña(contraseña);

    for (int i = 0; i < nombres_reglas.Length; i++)
    {
        Console.WriteLine($"{(reglas[i] ? "✔" : "✘")} {nombres_reglas[i]}");
    }

    Console.WriteLine($"Nivel: {nivel} ({puntaje}/{reglas.Length})");

    if (nivel == "Fuerte") break;

    Console.WriteLine();
}

static (bool[] Reglas, int Puntaje, string Nivel) EvaluarContraseña(string contraseña)
{
    bool minimo_caracteres = contraseña.Length >= 8;
    bool tiene_mayuscula = false, tiene_minuscula = false, tiene_digito = false, tiene_especial = false;
    bool tiene_espacios = false;

    foreach (char c in contraseña)
    {
        if (char.IsUpper(c)) tiene_mayuscula = true;
        else if (char.IsLower(c)) tiene_minuscula = true;
        else if (char.IsDigit(c)) tiene_digito = true;
        else if (char.IsSymbol(c) || char.IsPunctuation(c)) tiene_especial = true;
        else if (char.IsWhiteSpace(c)) tiene_espacios = true;
    }

    bool[] reglas =
    {
        minimo_caracteres,
        tiene_mayuscula,
        tiene_minuscula,
        tiene_digito,
        tiene_especial,
        !tiene_espacios
    };

    int puntaje = reglas.Count(cumple => cumple);
    string nivel = puntaje == reglas.Length ? "Fuerte" : puntaje >= 4 ? "Media" : "Débil";

    return (reglas, puntaje, nivel);
}