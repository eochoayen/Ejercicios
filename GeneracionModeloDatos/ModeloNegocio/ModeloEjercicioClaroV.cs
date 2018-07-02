using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Utilizar EF
using Microsoft.EntityFrameworkCore;

namespace ModeloDatosAcceso.ModeloNegocio
{
    public class ModeloEjercicioClaroV : DbContext

    {
        public DbSet<Listas> listas { get; set; }
        public DbSet<DetalleLista> detallesLista { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            string inicio = "";

            optionsBuilder.UseSqlite("Data Source=Filename=sqliteEjercicioClaroV.db");

            string fin = "";
            /*
             * Ejecutar en el directorio que contiene el .csproj
            dotnet add package Microsoft.EntityFrameworkCore.Sqlite 
            (C:\Raz\CARSO\VS2015EjercicioClaroV\UwpAppEjercicioClaroV\UwpAppEjercicioClaroV>dotnet add package Microsoft.EntityFrameworkCore.Sqlite)
            */

        }

    }






    /*
    public class Lista
    {
        public int ListaId { get; set; }
        public string ListaNombre { get; set; }
    }




    public class DetalleEnLista
    {
        public int DetalleListaId { get; set; }
        public int ListaId { get; set; }
        public string Cancion { get; set; }
        public string Artista { get; set; }
        public string Album { get; set; }
        public string Duracion { get; set; }
    }
    */

}
