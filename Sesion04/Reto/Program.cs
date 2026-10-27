Dictionary<string, List<double>> aprendiz_y_notas = new(StringComparer.OrdinalIgnoreCase);

const double notaAprobacion = 3.0;

int opcion;

do
{
    opcion = Menu();

    switch (opcion)
    {
        case 1: RegistrarAprendiz(); break;
        case 2: AgregarNota(); break;
        case 3: ListarAprendices(); break;
        case 4: MostrarRanking(); break;
        case 5: MostrarMejorYAprobados(); break;
        case 6: EliminarAprendiz(); break;
        case 7: Console.WriteLine("Saliendo del sistema..."); break;
    }

} while (opcion != 7);

int Menu()
{
    Console.WriteLine("\n===================");
    Console.WriteLine("SISTEMA SENA");
    Console.WriteLine("===================");
    Console.WriteLine("1 - Registrar aprendiz");
    Console.WriteLine("2 - Agregar nota");
    Console.WriteLine("3 - Listar aprendices");
    Console.WriteLine("4 - Ranking");
    Console.WriteLine("5 - Mejor aprendiz y aprobados");
    Console.WriteLine("6 - Eliminar aprendiz");
    Console.WriteLine("7 - Salir");
    Console.Write("Elija una opción: ");

    int opcionMenu;

    while (!int.TryParse(Console.ReadLine(), out opcionMenu) || opcionMenu < 1 || opcionMenu > 7)
    {
        Console.Write("Opción inválida. Ingrese un número del 1 al 7: ");
    }

    return opcionMenu;
}

void RegistrarAprendiz()
{
    int cantidad;

    do
    {
        Console.Write("¿Cuántos aprendices desea registrar?: ");
    }
    while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0);

    for (int i = 1; i <= cantidad; i++)
    {
        Console.Write($"Ingrese el nombre del aprendiz {i}: ");
        string nombre = (Console.ReadLine() ?? "").Trim();

        while (string.IsNullOrWhiteSpace(nombre) || aprendiz_y_notas.ContainsKey(nombre))
        {
            Console.Write("Nombre vacío o repetido. Ingrese otro: ");
            nombre = (Console.ReadLine() ?? "").Trim();
        }

        aprendiz_y_notas.Add(nombre, []);
        Console.WriteLine("Aprendiz registrado correctamente.");
    }
}

void AgregarNota()
{
    Console.Write("Ingrese el nombre del aprendiz: ");
    string nombre = (Console.ReadLine() ?? "").Trim();

    if (!aprendiz_y_notas.TryGetValue(nombre, out List<double>? notas))
    {
        Console.WriteLine("El aprendiz no existe.");
        return;
    }

    int cantidadNotas;

    do
    {
        Console.Write("¿Cuántas notas desea agregar?: ");
    }
    while (!int.TryParse(Console.ReadLine(), out cantidadNotas) || cantidadNotas <= 0);

    for (int i = 1; i <= cantidadNotas; i++)
    {
        double nota;

        while (true)
        {
            Console.Write($"Ingrese la nota {i} (0 a 5): ");

            if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 5)
            {
                break;
            }
            Console.WriteLine("Nota inválida. Intente nuevamente.");
        }

        notas.Add(nota);
        Console.WriteLine("Nota agregada.");
    }
}

void ListarAprendices()
{
    if (aprendiz_y_notas.Count == 0)
    {
        Console.WriteLine("No hay aprendices registrados.");
        return;
    }

    foreach (var aprendiz in aprendiz_y_notas)
    {
        if (aprendiz.Value.Count == 0)
        {
            Console.WriteLine($"{aprendiz.Key,-15} 0 notas · Sin promedio · Juicio N/A");
            continue;
        }

        double promedio = aprendiz.Value.Average();
        string juicio = promedio >= notaAprobacion ? "A" : "D";

        Console.WriteLine($"{aprendiz.Key,-15} {aprendiz.Value.Count} notas · Promedio {promedio:F1} · Juicio {juicio}");
    }
}

void MostrarRanking()
{
    var ranking = aprendiz_y_notas
        .Where(a => a.Value.Count > 0)
        .Select(a => new { Nombre = a.Key, Promedio = a.Value.Average() })
        .OrderByDescending(a => a.Promedio)
        .ToList();

    if (ranking.Count == 0)
    {
        Console.WriteLine("No hay aprendices con notas.");
        return;
    }

    Console.WriteLine("===== RANKING =====");

    for (int i = 0; i < ranking.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ranking[i].Nombre,-15} Promedio {ranking[i].Promedio:F1}");
    }
}

void MostrarMejorYAprobados()
{
    var aprendices = aprendiz_y_notas
        .Where(a => a.Value.Count > 0)
        .Select(a => new { Nombre = a.Key, Promedio = a.Value.Average() })
        .ToList();

    if (aprendices.Count == 0)
    {
        Console.WriteLine("No hay aprendices con notas.");
        return;
    }

    double mejorPromedio = aprendices.Max(a => a.Promedio);

    Console.WriteLine("===== MEJOR APRENDIZ =====");

    foreach (var aprendiz in aprendices.Where(a => a.Promedio == mejorPromedio))
    {
        Console.WriteLine($"{aprendiz.Nombre} · Promedio {aprendiz.Promedio:F1}");
    }

    int aprobados = aprendices.Count(a => a.Promedio >= notaAprobacion);

    Console.WriteLine($"Cantidad de aprobados: {aprobados}");
}

void EliminarAprendiz()
{
    Console.Write("Ingrese el nombre del aprendiz a eliminar: ");
    string nombre = (Console.ReadLine() ?? "").Trim();

    if (aprendiz_y_notas.Remove(nombre))
    {
        Console.WriteLine("Aprendiz eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("El aprendiz no existe.");
    }
}