using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese su usuario: ");
            string usuario = Console.ReadLine() ?? "".ToLower().Trim();
            Console.Write("Ingrese su contraseña: ");
            string clave = Console.ReadLine() ?? "".ToLower().Trim();
            
            if (usuario == "admin" && clave == "1234")
            {
                Console.WriteLine("Bienvenido Administrador");
                
                Console.Write("Ingrese un valor para a y b, primero A: ");
                string entrada = Console.ReadLine().Trim();
                float a = Convert.ToInt32(entrada);
                Console.Write("Ingrese el valor para B: ");
                entrada = Console.ReadLine().Trim();
                float b = Convert.ToInt32(entrada);

                Console.WriteLine($"Los valores ingresados fueron: A = {a} , B = {b}");

                Console.WriteLine("Ingrese la opcion deseada:\n1 - Sumar\n2 - Restar\n3 - Multiplicar\n4 - Dividir\n5 - Notas");
                int opc = Convert.ToInt32(Console.ReadLine().Trim());

                switch (opc)
                {
                    case 1:
                        Console.WriteLine($"La suma entre {a} y {b} es: {a + b}");
                        break;
                    case 2:
                        Console.WriteLine($"La resta entre {a} y {b} es: {a - b}");
                        break;
                    case 3:
                        Console.WriteLine($"La multiplicacion entre {a} y {b} es: {a * b}");
                        break;
                    case 4:
                        if (b == 0)
                            Console.WriteLine("No se puede dividir entre 0");
                        else
                            Console.WriteLine($"La division entre {a} y {b} es: {a / b}");
                        break;
                    case 5:
                        Console.WriteLine("Cual es tu nota?");
                        double nota = Convert.ToDouble(Console.ReadLine().Trim());

                        if (nota < 0 || nota > 5.0)
                            Console.WriteLine("Nota invalida, menor a 0 o mayor a 5");
                        else if (nota >= 4.6)
                            Console.WriteLine("Tu nota es Excelente");
                        else if (nota >= 4.0)
                            Console.WriteLine("Tu nota es Sobresaliente");
                        else if (nota >= 3.0)
                            Console.WriteLine("Tu nota es Aceptable");
                        break;
                    default:
                        Console.WriteLine("Eleccion incorrecta o invalida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Usuario o clave incorrectos");
            }
        }
    }
}