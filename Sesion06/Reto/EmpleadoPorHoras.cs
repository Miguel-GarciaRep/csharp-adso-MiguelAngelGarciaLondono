public class EmpleadoPorHoras : Empleado
{
    private const int HorasNormales = 160;

    public int Horas { get; }
    public decimal ValorHora { get; }

    public EmpleadoPorHoras(string nombre, string documento, int horas, decimal valorHora)
        : base(nombre, documento)
    {
        Horas = horas;
        ValorHora = valorHora;
    }

    public override string Tipo => "Por horas";

    // Las horas por encima de 160 se pagan a 1,5 veces el valor hora.
    public override decimal CalcularSalario()
    {
        int horasNormales = Math.Min(Horas, HorasNormales);
        int horasExtra = Math.Max(Horas - HorasNormales, 0);

        return horasNormales * ValorHora + horasExtra * ValorHora * 1.5m;
    }
}
