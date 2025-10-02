using System;

namespace Ejercicio1.models
{
    internal class Cuenta : IComparable
    {
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public double Importe { get; set; }

        public Cuenta(string nombre, int dni, double importe) 
        { 
            this.Nombre = nombre;
            this.DNI = dni;
            this.Importe = importe;
        }

        public Cuenta(int dni)
        {
            this.DNI = dni;
        }

        public override string ToString()
        {
            return $"Cuenta \n Nombre: {Nombre} \r\n DNI: {DNI} \r\n Importe: {Importe}";
        }

        public int CompareTo(object obj)
        {
            Cuenta A = obj as Cuenta;
            if (A == null)
            {
                return this.DNI.CompareTo(A.DNI);
            }
            return -1;
        }
    }
}
