using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AitorAyestaranLibros.Entidades
{
    public class Libro
    {
        #region Autopropiedades
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public int Paginas { get; set; }
        public bool Formato { get; set; }
        #endregion
        public string FormatoString() // Función que devuelve el formato a partir de la propiedad booleana Formato
        {
            if (Formato)
            {
                return "Digital";
            }
            else
            {
                return "Papel";
            }
        }
        #region Constructores
        public Libro() { } 
        
        public Libro(string titulo, string isbn, int paginas, bool formato)
        {
            Titulo = titulo;
            Isbn = isbn;
            Paginas = paginas;
            Formato = formato;
        }
        #endregion
        public override string ToString()
        {
            return $" Título: {Titulo}\n ISBN: {Isbn}\n Número de páginas: {Paginas}\n Formato: {FormatoString()}";
        }
    }
}
