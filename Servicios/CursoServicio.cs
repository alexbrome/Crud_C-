using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trabajointerfaces.Modelo;

namespace trabajointerfaces.Servicios
{
    public class CursoServicio
    {
     
        //Esto es un bean que crea una instancia de Curso Servicio bajo el patron Singleton que se utilizará en toda la app
        public static CursoServicio singleton
        {
            get
            {
                instance ??= new CursoServicio();
                return instance;
            }
        }

        //Instancia singleton y lista de cursos(Acceso a datos)
        private static CursoServicio instance;
        private List<Curso> ListaCursos;

        public CursoServicio()
        {
            ListaCursos = new List<Curso>
            {
                new Curso("7859","1DAM"),
                new Curso("34456","2DAM"),
                new Curso("2345","DataScience"),
                new Curso("87464","Testing")
            };

            foreach (Curso curso in ListaCursos) {
                if (curso.Identificador.Equals("7859"))
                {
                    curso.AgregarAlumno(new Alumno("78598745e", "Alejandro", "Brome"));
                    curso.AgregarAlumno(new Alumno("564566456c", "Rafaé", "Munyoz"));
                    curso.AgregarAlumno(new Alumno("56456456c", "Juan", "Lopez"));
                    curso.AgregarAlumno(new Alumno("56777889", "Daniel", "Benitez"));
                }
                if (curso.Identificador.Equals("34456"))
                {
                    curso.AgregarAlumno(new Alumno("4995225", "Tito", "Amado"));
                    curso.AgregarAlumno(new Alumno("7766766", "Pepe", "Malafel"));
                    curso.AgregarAlumno(new Alumno("6577676", "Rocio", "Herrera"));
                    curso.AgregarAlumno(new Alumno("6565678", "Laura", "Canaves"));
                }
                if (curso.Identificador.Equals("2345"))
                {
                    curso.AgregarAlumno(new Alumno("547788", "Luis", "Papafrita"));
                    curso.AgregarAlumno(new Alumno("454533543", "Joaquin", "Munyoz"));
                    curso.AgregarAlumno(new Alumno("09445544", "Sofia", "Borbon"));
                    curso.AgregarAlumno(new Alumno("7876876", "Carlos" ,"Benitez"));
                }
                if (curso.Identificador.Equals("87464"))
                {
                    curso.AgregarAlumno(new Alumno("567833", "Oscar", "Sanchez"));
                }
            }


        }
       

        //Metodo obtener todos los cursos

       public void InsertarCurso(Curso curso)
        {
            if (ListaCursos.Any(c => c.Identificador == curso.Identificador))
            {
                throw new Exception("El curso ya existe");
            }
            ListaCursos.Add(curso);
        }

        //Metodo obtener lista de Cursos
        public List<Curso> getCursos() { return ListaCursos; }

        
        //Metodo para comprobar si existe el socio
        public bool CursoExiste(int id)
        {
            return ListaCursos.Any(c=>c.Identificador.Equals(id));
        }

        //Metodo para registrar un alumno a un curso

        public void registrarAlumno(Curso curso , Alumno alumno)
        {
            Curso cursoExiste = ListaCursos.FirstOrDefault(c => c.Identificador.Equals(curso.Identificador));
            //Si el curso existe se le agrega el alumno
            if (cursoExiste != null) {
                cursoExiste.AgregarAlumno(alumno);
           }
            
          
        }

        //Metodo para eliminar curso
        public void EliminarCurso(Curso curso)
        {
            ListaCursos.Remove(curso);

        }


        //Metodo para actualizar socio
        public void ActualizarCurso(Curso cursoActualizado)
        {
            // Buscar el índice del socio en la lista por su DNI
            int indice = ListaCursos.FindIndex(s => s.Identificador == cursoActualizado.Identificador);

            if (indice != -1)
            {
                // Actualizar los datos del curso existente
                ListaCursos[indice].Nombre = cursoActualizado.Nombre;
                ListaCursos[indice].Identificador = cursoActualizado.Identificador;


                // Asignar la nueva lista de alumnos directamente
                //ListaCursos[indice].ListaAlumnos = cursoActualizado.ListaAlumnos;
            }
        }

       




    }
   
    
}
