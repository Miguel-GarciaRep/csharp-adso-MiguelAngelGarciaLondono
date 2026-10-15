using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto_sesion02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc;
            int opc_saldo;
            int saldo = 500000;
            int pin;
            int contador_pin = 0;
            int pin_correcto = 1234;

            do
            {
                Console.Write("Ingrese su pin: ");

                if (!int.TryParse(Console.ReadLine(), out pin) || pin != pin_correcto)
                {
                    contador_pin++;
                    Console.WriteLine($"Pin incorrecto, a usado {contador_pin} de 3 intentos");
                }

                if (contador_pin == 3)
                {
                    Console.WriteLine("Alcanzo el maximo de intentos, fue baneado de Bancolombia jeje, perdio tarjeta tambien jeje y nos quedamos con la liga jeje");
                    return;
                }
            } while (pin != pin_correcto);

            do
            {
                do
                {
                    Console.Write("Bienvenido al cajero, escoje tu opcion:\n1. Consultar saldo\n2. Depositar\n3. Retirar\n4. Salir\n===================\nOpcion: ");
                } while (!int.TryParse(Console.ReadLine(), out opc) || opc < 0 || opc > 4);

                switch (opc)
                {
                    case 1:
                        Console.WriteLine($"Tu saldo es de: {saldo} pesos");
                        break;

                    case 2:
                        do
                        {
                            Console.Write("Cuanto deseas depositar?: ");

                            if (!int.TryParse(Console.ReadLine().Trim(), out opc_saldo) || opc_saldo <= 0)
                            {
                                Console.WriteLine($"Ingrese un valor mayor a 0");
                            }
                            else
                            {
                                saldo += opc_saldo;
                                Console.WriteLine($"Saldo agregado exitosamente!, su nuevo saldo es {saldo}");
                                break;
                            }
                        } while (!int.TryParse(Console.ReadLine().Trim(), out opc_saldo) || opc_saldo <= 0);
                        break;

                    case 3:
                        Console.Write("Cuando desea retirar?: ");
                        int retiro = Convert.ToInt32(Console.ReadLine().Trim());

                        if (retiro % 10000 == 0 && retiro <= saldo && retiro >= 1)
                        {
                            saldo -= retiro;
                            Console.WriteLine($"Saldo retirado existosamente!, su nuevo saldo es {saldo}");
                        }
                        else
                        {
                            Console.WriteLine("Saldo menor al retiro u a o retiro no dentro de multiplos de 10.000");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Adios, te esperaremos pronto!");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida o no existente");
                        break;
                }
            } while (opc != 4);
        }
    }
}
