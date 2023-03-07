using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operaciones_matematicas_CCJR_OABC
{
    internal class Program
    {
        static string VerificarPar(int Numero)
        {
            if (Numero % 2 == 0)
            {
                return "Es";
            }
            return "No es";
            
        }
        static string VerificarPrimo(int Numero)
        {
            if (Numero > 1)
            {
                for (int i = 2; i < Numero; i++)
                {
                    if (Numero % i == 0)
                    {
                        return "no es";
                    }
                }
                return "es";
            }
            return "no es";
        }
        static string VerificarPerfecto(int Numero)
        {
            int Suma = 0;  
            for (int i = 1; i < Numero; i++)
            {
                if (Numero % i == 0)
                {
                    Suma += i;
                }
            }
            if (Suma == Numero)
            {
                return "es";
            }
            return "no es";

        }
        static void ImprimirIngresarNumeros(List<int> Numeros)
        {
            Console.Clear();
            Console.WriteLine("Calculando si un numero es: par, primo y perfecto\n");
            if (Numeros.Count > 0)
            {
                Console.Write("Tus numeros son:");
                foreach (var Numero in Numeros)
                {
                    Console.Write(" {0}", Numero);
                }
                Console.WriteLine("\n");
                Console.WriteLine("Presiona 'q' para agregar un nuevo numero");
            }
            else
            {
                Console.WriteLine("Presiona 'q' para agregar un numero");
            }
            Console.WriteLine("Presiona 'w' para calcular todos los numeros");
            Console.WriteLine("Presiona 'e' para calcular numero a numero");
            Console.WriteLine("Presiona 'r' para reiniciar el programa");
        }
        static void ImprimirOpcionesNumeroaNumero(List<char>  Opciones) 
        {
            Console.Clear();
            if (Opciones.IndexOf('a') == -1)
            {
                Console.WriteLine("Presiona 'a' para verificar si es par");
            }
            if (Opciones.IndexOf('s') == -1)
            {
                Console.WriteLine("Presiona 's' para verificar si es primo");

            }
            if (Opciones.IndexOf('d') == -1)
            {
                Console.WriteLine("Presiona 'd' para verificar si es perfecto");

            }
            if (Opciones.IndexOf('f') == -1)
            {
                Console.WriteLine("Presiona 'f' para continuar con el siguiente numero\n\n");

            }
            

        }
        static void RecorrerNumerosOpciones(int Numero)
        {
            List<char> Opciones = new List<char>();
            while (true) 
            {
                ImprimirOpcionesNumeroaNumero(Opciones);
                if (Opciones.IndexOf('a') != -1)
                {
                    Console.WriteLine("\t{0}, {1} par", Numero, VerificarPar(Numero));
                }
                if (Opciones.IndexOf('s') != -1)
                {
                    Console.WriteLine("\t{0}, {1} primo", Numero, VerificarPrimo(Numero));
                }
                if (Opciones.IndexOf('d') != -1)
                {
                    Console.WriteLine("\t{0}, {1} perfecto", Numero, VerificarPerfecto(Numero));
                }
                if (Opciones.IndexOf('f') != -1)
                {
                    break;
                }
                Opciones.Add(Char.ToLower(Console.ReadKey(true).KeyChar));
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                char control;
                int NuevoNumero, Error = 0;
                List<int> Numeros = new List<int>();
                ImprimirIngresarNumeros(Numeros);
                while (true)
                {
                    control = Char.ToLower(Console.ReadKey(true).KeyChar);
                    if (control == 'q')
                    {
                        Console.Write("Escribe el numero:");
                        while (true)
                        {
                            NuevoNumero = int.Parse(Console.ReadLine());
                            if (Numeros.IndexOf(NuevoNumero) != -1 | NuevoNumero <= 0)
                            {
                                ImprimirIngresarNumeros(Numeros);
                                Error += 1;
                                Console.WriteLine("\n\tIngresaste una opcion incorrecta ( x{0} )\n\n", Error);
                                Console.WriteLine("El numero ya se encuentra en la lista o no es positivo, por favor ingrese uno diferente:");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Numeros.Add(NuevoNumero);
                        ImprimirIngresarNumeros(Numeros);
                    }else if (Numeros.Count() < 1)
                    {
                        ImprimirIngresarNumeros(Numeros);
                        Error += 1;
                        Console.WriteLine("\n\tNo hay valores para calcular o ingresaste una opcion incorrecta ( x{0} )",Error);
                    }else if (control == 'w')
                    {
                        ImprimirIngresarNumeros(Numeros);
                        Console.WriteLine("");
                        foreach (var Numero in Numeros)
                        {
                            Console.WriteLine("\t {0} | {1} par, {2} primo y {3} perfecto", Numero, VerificarPar(Numero), VerificarPrimo(Numero), VerificarPerfecto(Numero));
                        }
                    }else if (control == 'e')
                    {
                        foreach(var Numero in Numeros)
                        {
                            Console.WriteLine("");
                            RecorrerNumerosOpciones(Numero);
                        }
                    }else if (control == 'r')
                    {
                        break;
                    }
                    else
                    {
                        ImprimirIngresarNumeros(Numeros);
                        Error += 1;
                        Console.WriteLine("\n\tIngresaste una opcion incorrecta ( x{0} )", Error);
                    }
                }
                Console.WriteLine("\n\n\n\n\nPresiona una tecla para actualizar el programa");
                Console.ReadKey();
                Console.Clear();
                Numeros.Clear();
            }
        }
    }
}
