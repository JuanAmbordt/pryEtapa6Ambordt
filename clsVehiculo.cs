using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pryEtapa6Ambordt
{
    internal class clsVehiculo
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Image Imagen { get; set; }

        public clsVehiculo(string nombre, string tipo, Image imagen)
        {
            Nombre = nombre;
            Tipo = tipo;
            Imagen = imagen;
        }

        public static clsVehiculo CrearVehiculoAleatorio()
        {
            string[] nombres = { "Ferrari", "Lamborghini", "Porsche", "BMW", "Audi", "Yate", "Velero", "Crucero", "Boeing", "Airbus", "Cessna", "Gulfstream" };
            string[] tipos = { "Auto", "Barco", "Avión" };

            Random rnd = new Random();
            string nombreAleatorio = nombres[rnd.Next(nombres.Length)];
            string tipoAleatorio = tipos[rnd.Next(tipos.Length)];

            Image imagenAleatoria = null;

            return new clsVehiculo(nombreAleatorio, tipoAleatorio, imagenAleatoria);
        }
    }
}
