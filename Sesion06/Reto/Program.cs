List<Empleado> nomina =
[
    new EmpleadoPlanta("Ana Gómez", "1001", 3_200_000m, 6),
    new EmpleadoPlanta("Luis Pérez", "1002", 2_800_000m, 2),
    new EmpleadoPorHoras("Marta Ruiz", "1003", 170, 18_000m),
    new EmpleadoPorHoras("Jorge Díaz", "1004", 120, 18_000m),
    new Contratista("Sofía León", "1005", 4_000_000m)
];

Console.WriteLine("=== NÓMINA ===");
foreach (Empleado empleado in nomina)
{
    Console.WriteLine(empleado);
}

decimal total = nomina.Sum(e => e.CalcularSalario());
Empleado mayorPago = nomina.MaxBy(e => e.CalcularSalario())!;

Console.WriteLine();
Console.WriteLine($"Total de la nómina: {Empleado.Dinero(total)}");
Console.WriteLine($"Mayor pago: {mayorPago.Nombre} ({Empleado.Dinero(mayorPago.CalcularSalario())})");

Console.WriteLine();
Console.WriteLine("Total por tipo:");
foreach (var grupo in nomina.GroupBy(e => e.Tipo))
{
    Console.WriteLine($"- {grupo.Key}: {Empleado.Dinero(grupo.Sum(e => e.CalcularSalario()))}");
}

// Nivel extra: solo EmpleadoPlanta implementa IBonificable.
decimal totalBonos = nomina.OfType<IBonificable>().Sum(b => b.CalcularBono());
Console.WriteLine();
Console.WriteLine($"Total de bonos: {Empleado.Dinero(totalBonos)}");
