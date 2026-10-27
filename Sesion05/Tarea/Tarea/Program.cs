using System;

namespace Tarea
{
    internal class Program
    {
        static void Main()
        {
            CuentaBancaria cuentaAna = new CuentaBancaria("Ana Gómez", "001-1234", 100000m);
            CuentaBancaria cuentaLuis = new CuentaBancaria("Luis Pérez", "001-5678");

            MostrarSaldos(cuentaAna, cuentaLuis);

            bool deposito = cuentaAna.Depositar(50000m);
            Console.WriteLine($"\nDepósito de 50.000 a Ana: {(deposito ? "Aceptado" : "Rechazado")}");

            bool retiro = cuentaAna.Retirar(500000m);
            Console.WriteLine($"Retiro de 500.000 de Ana: {(retiro ? "Aceptado" : "Rechazado")}");

            bool transferencia = cuentaAna.Transferir(cuentaLuis, 30000m);
            Console.WriteLine($"Transferencia de 30.000 de Ana a Luis: {(transferencia ? "Aceptada" : "Rechazada")}");

            MostrarSaldos(cuentaAna, cuentaLuis);

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }

        static void MostrarSaldos(CuentaBancaria a, CuentaBancaria b)
        {
            Console.WriteLine($"{a.Titular} ({a.Numero}): {a.Saldo:C0}");
            Console.WriteLine($"{b.Titular} ({b.Numero}): {b.Saldo:C0}");
        }
    }
}