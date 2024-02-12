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
    public sealed partial class DetalleCurso : Page


    {

        public Curso Curso { get; set; }
        private CursoServicio CursoServicio { get; set; }

        public DetalleCurso()
        {
            InitializeComponent();
            GoBackButton.Loaded += GoBackButton_Loaded;
            CursoServicio = CursoServicio.singleton;
           

        }

        //Metodo del boton back 
        private void GoBackButton_Loaded(object sender, RoutedEventArgs e)
        {
            // When we land in page, put focus on the back button
            GoBackButton.Focus(FocusState.Programmatic);
        }

        //Metodo onNavigate
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Store the item to be used in binding to UI
            Curso = e.Parameter as Curso;

            if (Curso.ListaAlumnos.LongCount() > 0)
            {
                listaAlumnos.ItemsSource = Curso.ListaAlumnos;
            }
            else
            {
                tituloalumno.Text = "Ningun curso registrado";
                tituloalumno.Style = (Style)Application.Current.Resources["BodyStrongTextBlockStyle"];
            }
            ConnectedAnimation imageAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ForwardConnectedAnimation");
           
        }
        //Metodo para volver a la pagina anterior
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }



        //Metodo para eliminar Curso
        private void Btn_EliminarCurso(object sender, RoutedEventArgs e)
        {
            //Eliminar socio
            CursoServicio.EliminarCurso(Curso);
            //volver al listado de socios
            Frame.GoBack();
        }


        //metodo para editar curso
        private void Btn_EditarCurso(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CrearCurso), Curso, new SuppressNavigationTransitionInfo());
        }







    }
   
}
