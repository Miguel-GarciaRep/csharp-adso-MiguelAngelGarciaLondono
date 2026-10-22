using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.Write("Nombre completo: ");
string nombre_completo = Console.ReadLine() ?? "";

Console.Write("Documento: ");
string documento = Console.ReadLine() ?? "";

Console.WriteLine("Usuario: " + GenerarUsuario(nombre_completo, documento));
Console.WriteLine();

Console.Write("Escribe una frase: ");
string frase = Console.ReadLine() ?? "";

AnalizarFrase(frase);
static string GenerarUsuario(string nombre_completo, string documento)
{
    string[] palabras = nombre_completo.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    documento = documento.Trim();

    if (palabras.Length < 2 || documento.Length < 2)
    {
        return "Datos inválidos (escribe nombre y apellido, y un documento de 2 dígitos o más)";
    }

    string primera_letra = palabras[0].Substring(0, 1);

    string primer_apellido = palabras.Length >= 4 ? palabras[2] : palabras[1];

    string ultimos_digitos = documento.Substring(documento.Length - 2);

    return QuitarTildes(primera_letra + primer_apellido + ultimos_digitos);
}

static void AnalizarFrase(string frase)
{
    string[] palabras = frase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    if (palabras.Length == 0)
    {
        Console.WriteLine("La frase está vacía.");
        return;
    }

    StringBuilder frase_invertida = new StringBuilder();

    for (int i = palabras.Length - 1; i >= 0; i--)
    {
        frase_invertida.Append(palabras[i]);

        if (i > 0)
        {
            frase_invertida.Append(" ");
        }
    }

    Console.WriteLine("Cantidad de palabras: " + palabras.Length);
    Console.WriteLine("Frase invertida: " + frase_invertida);
}

static string QuitarTildes(string texto)
{
    return texto.ToLower()
        .Replace('á', 'a')
        .Replace('é', 'e')
        .Replace('í', 'i')
        .Replace('ó', 'o')
        .Replace('ú', 'u')
        .Replace('ü', 'u')
        .Replace('ñ', 'n');
}