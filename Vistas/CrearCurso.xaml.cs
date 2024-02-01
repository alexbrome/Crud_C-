using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using trabajointerfaces.Servicios;
using trabajointerfaces.Modelo;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace trabajointerfaces.Vistas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CrearCurso : Page
    {

        private CursoServicio CursoServicio { get; set; }
        private bool IsEditCurso { get; set; }
        private bool IsNombreValid { get; set; }
        private bool IsIdentificadorValid { get; set; }

        public CrearCurso()
        {
            this.InitializeComponent();
            CursoServicio = CursoServicio.singleton;
            IsIdentificadorValid = false;
            IsNombreValid = false;
            IsEditCurso = false;
            GoBackButton.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Curso curso)
            {
                CargarDatosForm(curso);
            }
        }

        //Metodo para cargar los datos en el componente

        private void CargarDatosForm(Curso curso)
        {
            IsEditCurso = true;
            //desabilitar edicion del Dni
            txtIdentificador.IsEnabled = false;
            IsIdentificadorValid = true;
            //Actualizar formulario a tipo edicion
            titulo.Text = "Actualizar Curso";
            btnGuardar.Content = "Actualizar";
            btnGuardar.Background = new SolidColorBrush(Colors.Aqua);
            //cargas datos del socio
            txtIdentificador.Text = curso.Identificador;
            txtNombre.Text = curso.Nombre;
            GoBackButton.Visibility = Visibility.Visible;
        }


        //Metodo del boton para registrar curso
        private void btn_RegistrarSocio(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int numeroRandom = random.Next(1, 100);

            Curso curso = new Curso(
                    txtIdentificador.Text,
                    txtNombre.Text
                );
            if (IsEditCurso)
            {
                //actualizar Curso en CursoServicio
                CursoServicio.ActualizarCurso(curso);
                Frame.Navigate(typeof(DetalleCurso), curso, new SuppressNavigationTransitionInfo());

            }
            else
            {


                //registrar Curso en CursoServicio
                CursoServicio.InsertarCurso(curso);
                // msj de exito
                alert.IsOpen = true;
                alert.Title = "Enhorabuena!";
                alert.Severity = InfoBarSeverity.Success;
                alert.Message = "Curso " + curso.Nombre + " registrado con exito!";
            }

            // Limpiar campos después de guardar
            CleanFields();
            // Resetear el estado de las validaciones
            ResetearValidaciones();


        }

        private void CleanFields()
        {
            txtIdentificador.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void ResetearValidaciones()
        {
            errorIdentificador.Visibility = Visibility.Collapsed;
            errorNombre.Visibility = Visibility.Collapsed;

            //Variables de validacion
            IsNombreValid = false;
            IsIdentificadorValid = false;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        //VAlidaciones

        private void GfIdentificador(object sender, RoutedEventArgs e)
        {
            ValidatorNombre();
        }
        private void TcIdentificador(object sender, TextChangedEventArgs e)
        {
            ValidatorNombre();
        }
        private void GfNombre(object sender, RoutedEventArgs e)
        {
            ValidatorNombre();
        }
        private void TcNombre(object sender, TextChangedEventArgs e)
        {
            ValidatorNombre();
        }

        //Validator nombre
        private void ValidatorNombre()
        {
            var FirstName = txtNombre.Text;

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrWhiteSpace(FirstName))
            {
                errorNombre.Visibility = Visibility.Visible;
                errorNombre.Text = "Ingresar un nombre";
                IsNombreValid = false;
            }

            else
            {
                errorNombre.Visibility = Visibility.Collapsed;
                IsNombreValid = true;
                IsNewSocioDataValid();
            }
}

        private void IsNewSocioDataValid()
        {
            //comprobar que todos los campos sean validos
            if (IsNombreValid &&  IsIdentificadorValid)
            {
                //Enable button
                btnGuardar.IsEnabled = true;
                alert.IsOpen = false;
            }
            else
            {
                //disable button
                btnGuardar.IsEnabled = true;


                // mensaje de error
                alert.IsOpen = true;
                alert.Title = "Error";
                alert.Severity = InfoBarSeverity.Error;
                //alert.Message = "Los Datos del curso no son correctos";
            }
        }


    }
}
