public class Contratista : Empleado
{
    public decimal ValorContrato { get; }

    public Contratista(string nombre, string documento, decimal valorContrato)
        : base(nombre, documento)
    {
        ValorContrato = valorContrato;
    }

    public override string Tipo => "Contratista";

    // Valor del contrato menos 10 % de retención.
    public override decimal CalcularSalario() => ValorContrato * 0.90m;
}
