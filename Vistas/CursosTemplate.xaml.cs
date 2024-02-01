using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using trabajointerfaces.Modelo;
using trabajointerfaces.Servicios;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace trabajointerfaces.Vistas
{

    public sealed partial class CursosTemplate : Page
    {
        //Instancias de Servicio y lista de cursos
        public ObservableCollection<Curso> Cursos { get; set; }

        private CursoServicio CursoServicio { get; set; }


        public CursosTemplate()
        {
            this.InitializeComponent();
             CursoServicio = CursoServicio.singleton;
            Cursos = new ObservableCollection<Curso>(CursoServicio.getCursos());
            collection.ItemsSource = Cursos;


        }


        private void collection_ItemClick(object sender, ItemClickEventArgs e)
        {
            Curso CursoSel = null;
            // Get the collection item corresponding to the clicked item.
            if (collection.ContainerFromItem(e.ClickedItem) is ListViewItem container)
            {
                // Stash the clicked item for use later. We'll need it when we connect back from the detailpage.
                CursoSel = container.Content as Curso;

                // Prepare the connected animation.
                // Notice that the stored item is passed in, as well as the name of the connected element.
                // The animation will actually start on the Detailed info page.
                
                var animation = collection.PrepareConnectedAnimation("ForwardConnectedAnimation", CursoSel, "connectedElement");

            }

            // Navigate to the DetailedInfoPage.
            // Note that we suppress the default animation.
            Frame.Navigate(typeof(DetalleCurso), CursoSel, new SuppressNavigationTransitionInfo());
        }
        private async void collection_Loaded(object sender, RoutedEventArgs e)
        {
            if (Cursos != null)
            {
                // If the connected item appears outside the viewport, scroll it into view.
                collection.ScrollIntoView(Cursos, ScrollIntoViewAlignment.Default);
                collection.UpdateLayout();

                // Play the second connected animation.
                ConnectedAnimation animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("BackConnectedAnimation");
                if (animation != null)
                {
                    // Setup the "back" configuration if the API is present.
                    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
                    {
                        animation.Configuration = new DirectConnectedAnimationConfiguration();
                    }

                    await collection.TryStartConnectedAnimationAsync(animation, Cursos, "connectedElement");
                }

                // Set focus on the list
                collection.Focus(FocusState.Programmatic);
            }
        }

    }

}
       
        
