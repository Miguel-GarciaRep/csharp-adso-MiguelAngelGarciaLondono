using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciclos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ciclo for
            /*for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"Valor {i}");
            }

            // Ciclo do while

            int edad;

            do
            {
                Console.WriteLine("Digite su edad");
            } while (!int.TryParse(Console.ReadLine(), out edad) || edad < 1 || edad > 120);*/

            //int suma = 0;
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.Write($"Puntaje {i}: ");
            //    int.TryParse(Console.ReadLine(), out int puntaje);
            //    suma += puntaje;
            //}
            //double promedio = suma / 5;
            //Console.WriteLine($"Promedio: {promedio}");

            double opc;
            do
            {
                Console.WriteLine("Bienvenido a la tabla de multiplicar, digita el numero de la tabla que necesitas:");
            } while (!double.TryParse(Console.ReadLine(), out opc) || opc < 0);

            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{opc} * {i} = {opc * i}\n");
            }

        }
    }
}
