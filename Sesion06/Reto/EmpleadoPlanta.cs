public class EmpleadoPlanta : Empleado, IBonificable
{
    public decimal SalarioMensual { get; }
    public int AniosAntiguedad { get; }

    public EmpleadoPlanta(string nombre, string documento, decimal salarioMensual, int aniosAntiguedad)
        : base(nombre, documento)
    {
        SalarioMensual = salarioMensual;
        AniosAntiguedad = aniosAntiguedad;
    }

    public override string Tipo => "Planta";

    // Con 5 años o más de antigüedad: 5 % de bonificación.
    public decimal CalcularBono() => AniosAntiguedad >= 5 ? SalarioMensual * 0.05m : 0m;

    public override decimal CalcularSalario() => SalarioMensual + CalcularBono();
}
