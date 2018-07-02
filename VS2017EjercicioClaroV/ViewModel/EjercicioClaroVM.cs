using ModeloDatosAcceso.ModeloNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InyeccionDependencias;

namespace VS2017EjercicioClaroV.ViewModel
{
    // Para Inyecion Dependencia nombre del proyecto 
    public class NombreProyecto : InterfaceDependencias
    {
        public NombreProyecto(string nombreProyecto)
        {
            proyecto = nombreProyecto;
        }
        public string proyecto { get; private set; }
    }

    // lista de elementos
    public class ListasClaroMusicaEjercicioViewModelListas : INotifyPropertyChanged
    {

        //public List<ListasViewModel> VMListas { get; set; }
        ObservableCollection<ListasViewModel> vmlistas;
        public ObservableCollection<ListasViewModel> VMListas
        {
            get
            {
                if (vmlistas == null)
                    vmlistas = new ObservableCollection<ListasViewModel>();
                return vmlistas;
            }
            set
            {
                vmlistas = value;
                OnPropertyRaised("VMListas");
            }
        }


        InterfaceDependencias proyectoDependencia;
        public string ProyectoDependencia
        {
            get
            {
                return proyectoDependencia.proyecto;
            }
        }


        public ListasClaroMusicaEjercicioViewModelListas(InterfaceDependencias proyecto)
        {
            proyectoDependencia = proyecto;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


    }

    public class ListasClaroMusicaEjercicioViewModelDetalleLista : INotifyPropertyChanged
    {

        //public List<ListasViewModel> VMListas { get; set; }
        ObservableCollection<DetalleListaViewModel> vmdetalleLista;
        public ObservableCollection<DetalleListaViewModel> VMDetalleListaListas
        {
            get
            {
                if (vmdetalleLista == null)
                    vmdetalleLista = new ObservableCollection<DetalleListaViewModel>();
                return vmdetalleLista;
            }
            set
            {
                vmdetalleLista = value;
                OnPropertyRaised("VMDetalleListaListas");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


    }



    // por elementos
    public class ListasViewModel : INotifyPropertyChanged
    {
        private long id;
        public long ListaId
        {
            get { return id; }
            set { id = value; OnPropertyRaised("ListaId"); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyRaised("Title"); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyRaised("Image"); }
        }
        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyRaised("Author"); }
        }

        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyRaised("Type"); }
        }

        private bool isfollowing;
        public bool IsFollowing
        {
            get { return isfollowing; }
            set { isfollowing = value; OnPropertyRaised("IsFollowing"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


    }


    public class DetalleListaViewModel : INotifyPropertyChanged
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; OnPropertyRaised("Id"); }
        }

        private long listaid;
        public long ListaId
        {
            get { return listaid; }
            set{ listaid = value; OnPropertyRaised("ListaId"); }
        }

        private long tracknumber;
        public long TrackNumber
        {
            get { return tracknumber; }
            set { tracknumber = value; OnPropertyRaised("TrackNumber"); }
        }
        private string internalid;
        public string InternalId
        {
            get { return internalid; }
            set { internalid = value; OnPropertyRaised("InternalId"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyRaised("Name"); }
        }
        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; OnPropertyRaised("Url"); }
        }
        private string duration;
        public string Duration
        {
            get { return duration; }
            set { duration = value; OnPropertyRaised("Duration"); }
        }
        private long durationinseconds;
        public long DurationInSeconds
        {
            get { return durationinseconds; }
            set { durationinseconds = value; OnPropertyRaised("DurationInSeconds"); }
        }
        private long albumid;
        public long AlbumId
        {
            get { return albumid; }
            set { albumid = value; OnPropertyRaised("AlbumId"); }
        }
        private string albumname;
        public string AlbumName
        {
            get { return albumname; }
            set { albumname = value; OnPropertyRaised("AlbumName"); }
        }
        private string artist;
        public string Artist
        {
            get { return artist; }
            set { artist = value; OnPropertyRaised("Artist"); }
        }
        private string artistid;
        public string ArtistId
        {
            get { return artistid; }
            set { artistid = value; OnPropertyRaised("ArtistId"); }
        }
        private string artists;
        public string Artists
        {
            get { return artists; }
            set { artists = value; OnPropertyRaised("Artists"); }
        }
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyRaised("Image"); }
        }
        private long songsourcetype;
        public long SongSourceType
        {
            get { return songsourcetype; }
            set { songsourcetype = value; OnPropertyRaised("SongSourceType"); }
        }
        private string listsourcetype;
        public string ListSourceType
        {
            get { return listsourcetype; }
            set { listsourcetype = value; OnPropertyRaised("ListSourceType"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


    }
    
    



}
