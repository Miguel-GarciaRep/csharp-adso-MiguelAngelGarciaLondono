using System.Globalization;

public abstract class Empleado
{
    public string Nombre { get; }
    public string Documento { get; }

    protected Empleado(string nombre, string documento)
    {
        Nombre = nombre;
        Documento = documento;
    }

    // Cada hija sobrescribe este valor para poder agrupar por tipo.
    public virtual string Tipo => "Empleado";

    public abstract decimal CalcularSalario();

    public static string Dinero(decimal valor) =>
        "$" + valor.ToString("N0", new CultureInfo("es-CO"));

    public override string ToString() =>
        $"{Nombre} ({Documento}) - {Tipo}: {Dinero(CalcularSalario())}";
}