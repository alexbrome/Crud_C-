using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using trabajointerfaces.Vistas;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml.Media.Animation;
using Windows.UI.ViewManagement;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace trabajointerfaces
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            this.InitializeComponent();
            
        }


        private void NvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args) 
        {
            
            
            
                // Obtener el Tag asociado al NavigationViewItem seleccionado.
                string selectedItemTag = args.InvokedItemContainer.Tag.ToString();

                // Navegar a la página correspondiente según el Tag.
                switch (selectedItemTag)
                {
               
                case "Cursos":
                        contentFrame.Navigate(typeof(CursosTemplate));
                        break;
                case "Alumnos":
                        contentFrame.Navigate(typeof(AlumnoTemplate));
                        break;
                case "Contacto":
                        contentFrame.Navigate(typeof(Contacto),null,null);
                        break;
                 case "CrearCurso":
                    contentFrame.Navigate(typeof(CrearCurso));
                    break;
                case "Ayuda":
                    String url = "https://alexbrome.github.io/indexC-/";
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        }
                        ) ;
                    break;
            }
        }

    }
}
