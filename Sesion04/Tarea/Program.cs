List<Venta> ventas =
[
    new("Portátil", "Medellín", 2, 2_800_000m),
    new("Mouse", "Bogotá", 10, 45_000m),
    new("Teclado", "Cali", 5, 120_000m),
    new("Monitor", "Medellín", 3, 750_000m),
    new("Mouse", "Medellín", 8, 45_000m),
    new("Portátil", "Bogotá", 1, 2_800_000m),
    new("Diadema", "Cali", 6, 180_000m),
    new("Monitor", "Bogotá", 2, 750_000m),
    new("Teclado", "Medellín", 4, 120_000m),
    new("Diadema", "Bogotá", 3, 180_000m),
    new("Portátil", "Cali", 2, 2_800_000m),
    new("Mouse", "Cali", 12, 45_000m)
];

decimal total = ventas.Sum(v => v.Cantidad * v.PrecioUnitario);
decimal promedio = ventas.Average(v => v.Cantidad * v.PrecioUnitario);

Console.WriteLine($"Total vendido: {total:C0}");
Console.WriteLine($"Promedio por venta: {promedio:C0}");

Console.WriteLine("\nVentas por ciudad:");
var porCiudad = ventas
    .GroupBy(v => v.Ciudad)
    .Select(g => new { Ciudad = g.Key, Total = g.Sum(v => v.Cantidad * v.PrecioUnitario) })
    .OrderByDescending(c => c.Total);

foreach (var c in porCiudad)
{
    Console.WriteLine($"{c.Ciudad,-10} {c.Total:C0}");
}

Console.WriteLine("\nTop 3 productos por ingresos:");
var top3 = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new { Producto = g.Key, Ingresos = g.Sum(v => v.Cantidad * v.PrecioUnitario) })
    .OrderByDescending(p => p.Ingresos)
    .Take(3);

foreach (var p in top3)
{
    Console.WriteLine($"{p.Producto,-10} {p.Ingresos:C0}");
}

var masVendido = ventas
    .GroupBy(v => v.Producto)
    .Select(g => new { Producto = g.Key, Unidades = g.Sum(v => v.Cantidad) })
    .MaxBy(p => p.Unidades);

Console.WriteLine($"\nProducto más vendido: {masVendido?.Producto} ({masVendido?.Unidades} unidades)");

record Venta(string Producto, string Ciudad, int Cantidad, decimal PrecioUnitario);