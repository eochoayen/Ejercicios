using ModeloDatosAcceso.Modelo;
using ModeloDatosAcceso.ModeloNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ModeloDatosAcceso.ModeloDatos
{
    public class AccesoADatos
    {

        string rutaDB = "";


        public AccesoADatos()
        {
            // No necesario se utilizara Sqlite generada en el ambito LocalState
            //rutaDB = obtenerDBlocal();

        }




        // ----- Operaciones en DB Listas
        public List<ListasMN> ObtenerListas()
        {

            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                return context.listas.ToList(); 
            }
        }

        // ----- Operaciones en DB Listas
        public List<ListasMN> ObtenerListasFiltrada(string filtro)
        {
            //List<ListasMN> resultado = new List<ListasMN>();
            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                return (from ls in context.listas where ls.Title.ToLower().Contains(filtro.ToLower()) select ls).ToList();
            }
            //return resultado;
            
        }

        // Obtener una sola lista
        public ListasMN obtenerListaPorId(long listaId )
        {
            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                return (from l in context.listas
                        where l.ListaId.Equals(listaId)
                        select l).FirstOrDefault();
            }
        }

        // Obtener detalle de lista
        public List<DetalleListaMN> obtenerDetalleListaPorId(long listaId)
        {
            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                return (from dl in context.detalleLista
                        where dl.ListaId.Equals(listaId)
                        select dl).ToList();
            }
        }

        public void AgregaLista(ListasMN lista)
        {
            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                if (lista.ListaId > 0)
                {
                    context.Attach(lista);
                    context.Update(lista);
                }
                else
                {
                    context.Add(lista);
                }

                context.SaveChanges();
            }
        }

        public void BorraLista(ListasMN lista)
        {
            using (var context = new ModeloEntityFrameworkEjercicioClaroV())
            {
                context.Remove(lista);
                context.SaveChanges();
            }
        }
        // ----- 

        // No necesario se utilizara Sqlite generada en el ambito LocalState
        /*
        public string obtenerDBlocal()
        {
            string ruta = "";
            // folder de LocalState en AppData
            ruta = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "sqliteEjercicioClaroV.db");
            // folder local de instalacion 
            StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            ruta = appInstalledFolder.Path;
            // Obtenemos el folder padre de la ruta de instalacion (para buscar el folder de la DB )
            DirectoryInfo parentDir = Directory.GetParent(ruta.EndsWith("\\") ? ruta : string.Concat(ruta, "\\"));
            ruta = parentDir.Parent.FullName;
            ruta = ruta + "\\SqliteDBEjercicioClaroV\\sqliteEjercicioClaroV.db";
            return ruta;



        }
        */


    }
}
