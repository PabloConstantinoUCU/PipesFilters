using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterSave : IFilter
    {
        public string Nombre { get; set; }
        public int Contador = 1;


        public FilterSave(string nombre)
        {
            this.Nombre = nombre + "0.jpg";
        }

        public void SetNombre()
        {
            string old = this.Nombre; 
            string nuevo = old.Remove(old.Length - 5, 5)+this.Contador.ToString()+".jpg";
            this.Nombre = nuevo;
            this.SetContador();
        }

        public void SetContador()
        {
            this.Contador += 1;
        }

        public IPicture Filter(IPicture image)
        {

            this.SetNombre();
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, this.Nombre);

            return image;
        }
    }
}
