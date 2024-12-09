using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadoObjetos.interfaces;

namespace OrientadoObjetos.clases
{
    public abstract class Bicicleta : IVehiculo
    {
        public int Velocidad { get; set; }
        public int Carrera { get; set; }

        public void CambiarCarrera(int x)
        {
            Carrera = x;
        }

        public void Acelerar(int x)
        {
            Velocidad += x;
        }

        public void AplicarFrenos(int x)
        {
            Velocidad -= x;
        }

        public void imprimirEstados()
        {
            Console.WriteLine($" Velocidad: {Velocidad} \n Carrera: {Carrera}");
        }
    }
}