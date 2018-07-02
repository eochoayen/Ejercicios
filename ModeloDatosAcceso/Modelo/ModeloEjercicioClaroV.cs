using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosAcceso.Modelo
{



    public class ListasMN
    {
        [Key]
        public long ListaId { get; set; }


        public string Title { get; set; }

        public string Image { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public bool IsFollowing { get; set; }
    }




    public class DetalleListaMN
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
