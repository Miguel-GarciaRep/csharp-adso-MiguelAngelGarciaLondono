using System.Text;
using Inventario.Datos;
using Inventario.Modelos;
using Inventario.Servicios;

Console.OutputEncoding = Encoding.UTF8;

var servicio = new ServicioInventario(new RepositorioJson("inventario.json"));

bool salir = false;
while (!salir)
{
    MostrarMenu();
    string opcion = LeerTexto("Opción: ");

    try
    {
        switch (opcion)
        {
            case "1": Registrar(); break;
            case "2": AgregarStock(); break;
            case "3": Vender(); break;
            case "4": MostrarProductos(servicio.Listar()); break;
            case "5": MostrarProductos(servicio.StockBajo()); break;
            case "6": Buscar(); break;
            case "7": Eliminar(); break;
            case "0": salir = true; break;
            default: Console.WriteLine("Opción no válida."); break;
        }
    }
    catch (StockInsuficienteException ex)
    {
        Console.WriteLine($"✘ {ex.Message}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"✘ {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"✘ {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }

    Console.WriteLine();
}

Console.WriteLine("¡Hasta pronto!");

void MostrarMenu()
{
    Console.WriteLine("=== INVENTARIO ===");
    Console.WriteLine("1. Registrar producto");
    Console.WriteLine("2. Agregar stock");
    Console.WriteLine("3. Vender");
    Console.WriteLine("4. Ver inventario");
    Console.WriteLine("5. Stock bajo");
    Console.WriteLine("6. Buscar por texto");
    Console.WriteLine("7. Eliminar producto");
    Console.WriteLine("0. Salir");
}

void Registrar()
{
    string codigo = LeerTexto("Código: ");
    string nombre = LeerTexto("Nombre: ");
    decimal precio = LeerDecimal("Precio: ");
    int stock = LeerEntero("Stock inicial: ");

    servicio.Agregar(new Producto(codigo, nombre, precio, stock));
    Console.WriteLine("✔ Producto registrado.");
}

void AgregarStock()
{
    string codigo = LeerTexto("Código: ");
    int cantidad = LeerEntero("Cantidad a agregar: ");

    servicio.AgregarStock(codigo, cantidad);
    Console.WriteLine("✔ Stock actualizado.");
}

void Vender()
{
    string codigo = LeerTexto("Código: ");
    int cantidad = LeerEntero("Cantidad a vender: ");

    servicio.Vender(codigo, cantidad);
    Console.WriteLine("✔ Venta registrada.");
}

void Buscar()
{
    string texto = LeerTexto("Texto a buscar (nombre o código): ");
    MostrarProductos(servicio.BuscarPorTexto(texto));
}

void Eliminar()
{
    string codigo = LeerTexto("Código a eliminar: ");
    Console.Write($"¿Seguro que quieres eliminar {codigo.ToUpperInvariant()}? (s/n): ");
    string respuesta = LeerTexto("").ToLowerInvariant();

    if (respuesta != "s")
    {
        Console.WriteLine("Eliminación cancelada.");
        return;
    }

    servicio.Eliminar(codigo);
    Console.WriteLine("✔ Producto eliminado.");
}

void MostrarProductos(List<Producto> productos)
{
    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos para mostrar.");
        return;
    }

    Console.WriteLine($"{"Código",-10}{"Nombre",-22}{"Precio",12}{"Stock",8}");
    foreach (Producto p in productos)
        Console.WriteLine($"{p.Codigo,-10}{p.Nombre,-22}{p.Precio,12:C0}{p.Stock,8}");
}

string LeerTexto(string mensaje)
{
    Console.Write(mensaje);
    return (Console.ReadLine() ?? "").Trim();
}

int LeerEntero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int numero)) return numero;
        Console.WriteLine("Escribe un número entero.");
    }
}

decimal LeerDecimal(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (decimal.TryParse(Console.ReadLine(), out decimal numero)) return numero;
        Console.WriteLine("Escribe un número válido.");
    }
}
