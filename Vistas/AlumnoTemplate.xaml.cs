using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using trabajointerfaces.Modelo;
using trabajointerfaces.Servicios;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace trabajointerfaces.Vistas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlumnoTemplate : Page
    {
        private CursoServicio CursoServicios { get; set; }
        public List<Curso> Cursos { get; set; }
        public Curso Curso { get; set; }
        public bool isDniValid {  get; set; }
        public bool isNombreValid { get; set; }
        public bool isApellidoValid {  get; set; }


        public AlumnoTemplate()
        {
            this.InitializeComponent();
            //Instancia de CursoServicio
            CursoServicios = CursoServicio.singleton;
            //Listado de cursos
            Cursos=CursoServicios.getCursos();
            //Listado de cursos al combobox
            cmbCursos.ItemsSource = Cursos;
            

            //Validaciones
            isDniValid = false;
            isNombreValid = false;
            isApellidoValid=false;
        }


        //Registrar Alumno
        private void btn_RegistrarALumno(object sender, RoutedEventArgs e)
        {
          
            Alumno MiALumno = new Alumno(
                txtDni.Text,
                txtNombre.Text,
                txtApellido.Text
                );

            //Guardar el Curso al alumno correspondiente

            CursoServicios.registrarAlumno(Curso, MiALumno);
            
            //Imprimir mensaje exitoso

            alert.IsOpen = true;
            alert.Title = "Enhorabuena!";
            alert.Severity = InfoBarSeverity.Success;
            alert.Message = "Alumno " + MiALumno.Nombre + " registrado con exito!";
            Frame.Navigate(typeof(CursosTemplate), Curso, new SuppressNavigationTransitionInfo());
        }

           

            //validacion Nombre
             void GfName(object sender, RoutedEventArgs e)
            {
                ValidatorName();
            }

             void TcName(object sender, TextChangedEventArgs e)
            {
                ValidatorName();
            }

            //Validacion apellido
             void GfApellidoFee(object sender, RoutedEventArgs e)
            {
               ValidatorApellido();
            }
             void TcApellidoFee(object sender, TextChangedEventArgs e)
            {
                ValidatorApellido();
            }

             void GfDni(object sender, RoutedEventArgs e)
            {
                ValidatorName();
            }
             void TcDni(object sender, TextChangedEventArgs e)
            {
                ValidatorName();
            }


        void ValidatorApellido()
        {
            var Apellido = txtApellido.Text;
            if (string.IsNullOrEmpty(Apellido) || string.IsNullOrWhiteSpace(Apellido))
            {
                errorApellido.Visibility = Visibility.Visible;
                errorApellido.Text = "Ingresar un Apellido";
                isApellidoValid = false;
            }

            else
            {
                errorApellido.Visibility = Visibility.Collapsed;
                isApellidoValid = true;
                IsNewCursoDataValid();
            }

        }

            //
           void ValidatorName()
            {
                var Name = txtNombre.Text;

                if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
                {
                    errorNombre.Visibility = Visibility.Visible;
                    errorNombre.Text = "Ingresar un nombre";
                    isNombreValid = false;
                }
               
                else
                {
                    errorNombre.Visibility = Visibility.Collapsed;
                    isNombreValid = true;
                    IsNewCursoDataValid();
                }
            }



        


        //Combo Cursos
        private void CmbCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Curso = cmbCursos.SelectedItem as Curso;
        }



        private void IsNewCursoDataValid()
        {
            //comprobar que todos los campos sean validos
            if (isNombreValid && isApellidoValid)
            {
                //habilitar boton
                btnGuardar.IsEnabled = true;
                alert.IsOpen = false;
            }
            else
            {
                //desabilitar boton
                btnGuardar.IsEnabled = false;
                // msj de error
                alert.IsOpen = true;
                alert.Title = "Error";
                alert.Severity = InfoBarSeverity.Error;
                alert.Message = "Los datos del alumno no son validos";
            }
        }



    }
}
