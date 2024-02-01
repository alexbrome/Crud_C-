using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajointerfaces.Modelo
{
    public class Alumno
    {
        // Atributos de la clase Alumno
        private string dni;
        private string nombre;      
        private string apellido;

        // Constructor para inicializar la clase Alumno
        public Alumno(string dni, string nombre,  string apellido)
        {
            this.dni = dni;
            this.nombre = nombre;          
            this.apellido = apellido;
        }

        // Propiedades para acceder a los atributos privados desde fuera de la clase
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

       

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        // Método para mostrar información del alumno
        public void MostrarInformacion()
        {
            Console.WriteLine($"DNI: {dni}");
            Console.WriteLine($"Nombre: {nombre}");
            
            Console.WriteLine($"Apellido: {apellido}");
        }

    }
}
