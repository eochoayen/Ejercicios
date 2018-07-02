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
using System.ComponentModel.DataAnnotations;

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






    
    public class Listas
    {
        [Key]
        public long ListaId { get; set; }


        public string Title { get; set; }

        public string Image { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public bool IsFollowing { get; set; }
    }




    public class DetalleLista
    {
        [Key]
        public long Id { get; set; }

        public long ListaId { get; set; }


        public long TrackNumber { get; set; }


        public string InternalId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Duration { get; set; }
        public long DurationInSeconds { get; set; }
        public long AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public string ArtistId { get; set; }
        public string Artists { get; set; }
        public string Image { get; set; }
        public long SongSourceType { get; set; }
        public string ListSourceType { get; set; }

    }
    

}
