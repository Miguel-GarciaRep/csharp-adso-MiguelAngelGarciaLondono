using System;
using System.Collections.Generic;
using System.Linq;

namespace Reto
{
    internal class Program
    {
        static List<Producto> inventario = new List<Producto>
        {
            new Producto("P001", "Cuaderno", 3500m, 20),
            new Producto("P002", "Lapicero", 1500m, 50),
            new Producto("P003", "Borrador", 800m, 30)
        };

        static List<LineaVenta> carrito = new List<LineaVenta>();

        static void Main()
        {
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();

                switch (Console.ReadLine())
                {
                    case "1": RegistrarProducto(); break;
                    case "2": AgregarStock(); break;
                    case "3": Vender(); break;
                    case "4": VerCarrito(); break;
                    case "5": VerInventario(); break;
                    case "6": salir = true; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== TIENDA =====");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Agregar stock");
            Console.WriteLine("3. Vender");
            Console.WriteLine("4. Ver carrito");
            Console.WriteLine("5. Ver inventario");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
        }

        static void RegistrarProducto()
        {
            Console.Write("Código: ");
            string codigo = Console.ReadLine() ?? "";
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            decimal precio = LeerDecimal("Precio: ");
            int stock = LeerEntero("Stock inicial: ");

            string codigoNormalizado = codigo.Trim().ToUpper();
            if (inventario.Any(p => p.Codigo == codigoNormalizado))
            {
                Console.WriteLine("Ya existe un producto con ese código.");
                return;
            }

            try
            {
                inventario.Add(new Producto(codigo, nombre, precio, stock));
                Console.WriteLine("Producto registrado.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"No se pudo registrar: {ex.Message}");
            }
        }

        static void AgregarStock()
        {
            Producto producto = BuscarProducto();
            if (producto == null) return;

            int cantidad = LeerEntero("Cantidad a agregar: ");

            try
            {
                producto.AgregarStock(cantidad);
                Console.WriteLine($"Stock actualizado: {producto.Stock}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"No se pudo agregar: {ex.Message}");
            }
        }

        static void Vender()
        {
            Producto producto = BuscarProducto();
            if (producto == null) return;

            int cantidad = LeerEntero("Cantidad a vender: ");

            if (!producto.Vender(cantidad))
            {
                Console.WriteLine("Cantidad inválida o stock insuficiente.");
                return;
            }

            carrito.Add(new LineaVenta(producto.Codigo, producto.Nombre, cantidad, producto.Precio * cantidad));
            Console.WriteLine("Producto agregado al carrito.");
        }

        static void VerCarrito()
        {
            if (carrito.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                return;
            }

            foreach (LineaVenta linea in carrito)
            {
                Console.WriteLine($"{linea.Codigo} | {linea.Nombre} | x{linea.Cantidad} | {linea.Subtotal:C0}");
            }

            decimal total = carrito.Sum(l => l.Subtotal);
            Console.WriteLine($"TOTAL: {total:C0}");
        }

        static void VerInventario()
        {
            foreach (Producto producto in inventario)
            {
                Console.WriteLine(producto);
            }
        }

        static Producto BuscarProducto()
        {
            Console.Write("Código del producto: ");
            string codigo = (Console.ReadLine() ?? "").Trim().ToUpper();

            Producto producto = inventario.FirstOrDefault(p => p.Codigo == codigo);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            return producto;
        }

        static int LeerEntero(string mensaje)
        {
            int numero;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Número entero no válido. " + mensaje);
            }
            return numero;
        }

        static decimal LeerDecimal(string mensaje)
        {
            decimal numero;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Número no válido. " + mensaje);
            }
            return numero;
        }
    }
}