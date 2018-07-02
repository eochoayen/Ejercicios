using ModeloDatosAcceso.ModeloDatos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VS2017EjercicioClaroV.ModeloNegocio;
using VS2017EjercicioClaroV.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VS2017EjercicioClaroV.Vista
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetalleVista : Page
    {

        //Datos de la lista
        ListasViewModel ListaElegida { get; set; }


        // Detalle de la lista
        ListasClaroMusicaEjercicioViewModelDetalleLista detalleListaElegida { get; set; }

        public DetalleVista(ListasViewModel lista)
        {
            this.InitializeComponent();
            ListaElegida = lista;
            

            // Obtener detalle de lista
            AccesoADatos accesoDB = new AccesoADatos();

            detalleListaElegida = new ListasClaroMusicaEjercicioViewModelDetalleLista();
            detalleListaElegida.VMDetalleListaListas = InterfazModeloVM.ObtieneDetalleListaVM(accesoDB.obtenerDetalleListaPorId(ListaElegida.ListaId));
            DetalleLista.ItemsSource = detalleListaElegida.VMDetalleListaListas;
            


            string nada = "";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Window.Current.Content = new ClaroMusicaEjercicio();

        }

        /*
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            long? ListaId = e.Parameter as long?;
            
        }

        */
    }
}
