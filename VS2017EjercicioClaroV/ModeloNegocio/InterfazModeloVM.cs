using ModeloDatosAcceso.Modelo;
using ModeloDatosAcceso.ModeloNegocio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VS2017EjercicioClaroV.ViewModel;

namespace VS2017EjercicioClaroV.ModeloNegocio
{
    public static class InterfazModeloVM
    {
        public static ListasViewModel ObtieneListaVM(ListasMN listasMN)
        {
            return new ListasViewModel()
            {
                ListaId = listasMN.ListaId,
                Title = listasMN.Title,
                Image = listasMN.Image,
                Author = listasMN.Author,
                Type = listasMN.Type,
                IsFollowing = listasMN.IsFollowing
            };
        }


        public static ObservableCollection<ListasViewModel> ObtieneListasVM(List<ListasMN> listasMN)
        {
            ObservableCollection<ListasViewModel> resultado = new ObservableCollection<ListasViewModel>();

            foreach (ListasMN lista in listasMN)
            {
                resultado.Add(
                    new ListasViewModel()
                    {
                        ListaId = lista.ListaId,
                        Title = lista.Title,
                        Image = lista.Image,
                        Author = lista.Author,
                        Type = lista.Type,
                        IsFollowing = lista.IsFollowing
                    }
                );
            }

            return resultado;

        }


        public static ObservableCollection<DetalleListaViewModel>  ObtieneDetalleListaVM(List<DetalleListaMN> detalleListaMN)
        {
            ObservableCollection<DetalleListaViewModel> resultado = new ObservableCollection<DetalleListaViewModel>();

            foreach (DetalleListaMN detallelista in detalleListaMN)
            {
                resultado.Add(
                    new DetalleListaViewModel()
                    {
                        Id = detallelista.Id,
                        ListaId = detallelista.ListaId,
                        TrackNumber = detallelista.TrackNumber,
                        InternalId = detallelista.InternalId,
                        Name = detallelista.Name,
                        Url = detallelista.Url,
                        Duration = detallelista.Duration,
                        DurationInSeconds = detallelista.DurationInSeconds,
                        AlbumId = detallelista.AlbumId,
                        AlbumName = detallelista.AlbumName,
                        Artist = detallelista.Artist,
                        ArtistId = detallelista.ArtistId,
                        Artists = detallelista.Artists,
                        Image = detallelista.Image,
                        SongSourceType = detallelista.SongSourceType,
                        ListSourceType = detallelista.ListSourceType
                    }
                );
            }
            return resultado;
        }



    }
}
