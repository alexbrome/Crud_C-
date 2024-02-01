using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace trabajointerfaces.Modelo
{
    public class Curso
    {

        // Atributos de la clase Curso
        public string Identificador {  get; set; }
        public string nombre {  get; set; }
        public List<Alumno> ListaAlumnos {  get; set; }

        // Constructor para inicializar la clase Curso
        public Curso(string Identificador, string nombre)
        {
            this.Identificador = Identificador;
            this.nombre = nombre;
            this.ListaAlumnos = new List<Alumno>();
        }

        // Propiedades para acceder a los atributos privados desde fuera de la clase
       

     
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

       //public List<Alumno> ListaAlumnos
        
         //  get { return ListaAlumnos; }
           // set { listaAlumnos = value; }
        //}

        // Método para agregar un alumno al curso
        public void AgregarAlumno(Alumno alumno)
        {
            ListaAlumnos.Add(alumno);
        }

        //Metodo para eliminar alumno

        public void eliminarAlumno(Alumno alumno)
        {
            ListaAlumnos.Remove(alumno);
        }


        // Método para mostrar información del curso
        public void MostrarInformacion()
        {
            Console.WriteLine($"Identificador del curso: {Identificador}");
            Console.WriteLine($"Nombre del curso: {nombre}");
            Console.WriteLine("Alumnos del curso:");

            foreach (var alumno in ListaAlumnos)
            {
                Console.WriteLine($"- {alumno.Nombre} {alumno.Apellido} (DNI: {alumno.Dni})");
            }
        }
    }
}
