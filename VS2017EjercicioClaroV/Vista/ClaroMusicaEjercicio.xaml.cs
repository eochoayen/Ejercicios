using InyeccionDependencias;
using ModeloDatosAcceso.ModeloDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using VS2017EjercicioClaroV.ModeloNegocio;
using VS2017EjercicioClaroV.ViewModel;
using VS2017EjercicioClaroV.Vista;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VS2017EjercicioClaroV
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClaroMusicaEjercicio : Page
    {
        // Acceso a datos
        AccesoADatos dbAcceso = new AccesoADatos();

        // Listas
        ListasClaroMusicaEjercicioViewModelListas listasClaro { get; set; }

        public ClaroMusicaEjercicio()
        {
            this.InitializeComponent();

            // no mostrar barra de titulo
            CoreApplicationViewTitleBar barraTitulo = CoreApplication.GetCurrentView().TitleBar;
            barraTitulo.ExtendViewIntoTitleBar = true;

            // Inicializacion de Datos
            NombreProyecto NombreDelProyecto = new NombreProyecto(" PROYECTO EJERCICIO CLARO VIDEO ");
            // Por inyeccion de dependencia se establece el nombre del proyecto
            listasClaro = new ListasClaroMusicaEjercicioViewModelListas(NombreDelProyecto);

            listasClaro.VMListas = InterfazModeloVM.ObtieneListasVM(dbAcceso.ObtenerListas());

            TodasLasListas.ItemsSource = listasClaro.VMListas;
    

        }

        // Filtrado
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Filtrado de las listas
            // Inicializacion de Datos

            
            
            listasClaro.VMListas = InterfazModeloVM.ObtieneListasVM(dbAcceso.ObtenerListasFiltrada(textBoxFiltro.Text));
            TodasLasListas.ItemsSource = listasClaro.VMListas;

        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            string borrame1 = "";

            string borrame2 = "";
        }

        // ir a detalle 
        private void TodasLasListas_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListasViewModel lista = (ListasViewModel)e.ClickedItem;

            long listaId = lista.ListaId;


            // misma ventana
            Window.Current.Content = new DetalleVista(lista);

            // nueva ventana
            //vistaDetalle(listaId);

        }
        
        /*
        private async void vistaDetalle(long ListaId)
        {
            ApplicationView currentAV = ApplicationView.GetForCurrentView();
            CoreApplicationView newAV = CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(
                            CoreDispatcherPriority.Normal,
                            async () =>
                            {
                                var newWindow = Window.Current;
                                var newAppView = ApplicationView.GetForCurrentView();
                                //newAppView.Title = "New window";

                                var frame = new Frame();
                                frame.Navigate(typeof(DetalleVista), null);
                                newWindow.Content = new DetalleVista(ListaId);
                                newWindow.Activate();

                            });
        }
        */

    }
}
