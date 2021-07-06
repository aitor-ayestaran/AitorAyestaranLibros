using System;
using System.Collections.Generic;
using AitorAyestaranLibros.Entidades;
namespace AitorAyestaranLibros.Presentacion
{
    public class Program
    {
        private static List<Libro> libros = new();
        static void Main()
        {
            Console.WriteLine("Bienvenido a la aplicación de la librería");
            bool seguir;
            do
            {
                AgregarLibro();
                Console.Write("Desea añadir otro libro?");
                seguir = PreguntarSiNo(); // Si se responde que si, se seguirá pidiendo datos
            }
            while (seguir);
            Console.WriteLine("Se han añadido los siguientes libros: ");
            foreach(var lib in libros) // Muestra cada uno de los libros que se han añadido
            {
                Console.WriteLine("============================================");
                Console.WriteLine(lib);
            }
        }

        private static void AgregarLibro()
        {
            var libro = new Libro();
            libro.Titulo = PedirTitulo();
            libro.Isbn = PedirIsbn();
            libro.Paginas = PedirPaginas();
            Console.Write("\nSe va a publicar en papel?");
            libro.Formato = !PreguntarSiNo(); 
            // Si la respuesta es no, el valor de la propiedad Formato del objeto libro será true
            // De lo contrario, si la respuesta es si, será false
            Console.WriteLine("\n" + libro); // Se muestran los datos del libro
            Console.Write("\nDesea guardar el libro?");
            if (PreguntarSiNo()) { libros.Add(libro);  }   // Si se responde que si, se guarda el libro en la lista.         
        }

        #region Funciones de introducción de datos
        /*
            Las siguentes funciones se encargan de validar los datos introducidos.
            En caso de no ser un dato válido, se informa del motivo.
            Se seguirá pidiendo cada dato hasta que sea válido.
        */
        private static string PedirTitulo()
        {
            string titulo;
            bool esValido;
            do
            {
                Console.Write("\nIntroduzca el título del libro: ");
                titulo = Console.ReadLine();
                esValido = (titulo.Trim().Length >= 3 && titulo.Trim().Length <= 150); 
                // esValido es true si el número de caracteres es correcto
                if (!esValido)
                {
                    PintarRojo("Debe ser un título entre 3 y 150 caracteres.");
                }
            }
            while (!esValido);
            return titulo;
        }

        private static string PedirIsbn()
        {
            long isbn;
            bool esValido;
            string isbnString;
            do
            {
                Console.Write("\nIntroduzca el ISBN: ");
                isbnString = Console.ReadLine();   
                esValido = long.TryParse(isbnString.Trim(), out isbn); // Comprobación de que sólo contenga dígitos
                if (esValido && isbnString.Length != 10) // Comprobación de la longitud del número
                {
                    esValido = false;
                }
                if (!esValido) 
                {
                    PintarRojo("El ISBN debe contener 10 dígitos.");
                }
            }
            while (!esValido);
            return isbnString;
        }

        private static int PedirPaginas()
        {
            bool esValido;
            int numero;
            do
            {
                Console.Write("\nIntroduzca el número de páginas: ");
                string numeroString = Console.ReadLine();
                esValido = int.TryParse(numeroString, out numero); //Comprobación de que es un número entero
                if (!esValido) { PintarRojo(numeroString + " No es un número de páginas válido"); }
                else
                {
                    if (numero < 0) // Verificación de que no es negativo
                    {
                        esValido = false;
                        PintarRojo($"El número de páginas no puede ser negativo.");
                    }
                    else if (numero < 1) //Verificación de que al menos tiene una página
                    {
                        esValido = false;
                        PintarRojo($"Debe tener al menos una página.");
                    }
                }
            }
            while (!esValido);
            return numero;
        }

        private static bool PreguntarSiNo()
        {
            string respuesta;
            do
            {
                Console.Write("(S/N): ");
                respuesta = Console.ReadLine().Trim().ToUpper();
                if (respuesta != "S" && respuesta != "N") // Verifica que la respuesta es válida
                {
                    PintarRojo("La respuesta debe ser S ó N.");
                }
            }
            while (respuesta != "S" && respuesta != "N");

            return respuesta == "S";
        }
        #endregion

        // Método para mostrar las advertencias en color rojo.
        private static void PintarRojo(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Cambia el color del texto
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.Gray; // Vuelve a dejar el color original
        }
    }
}
