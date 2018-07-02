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

namespace ModeloDatosAcceso.Modelo
{
    public class ModeloEntityFrameworkEjercicioClaroV : DbContext

    {
        public DbSet<ListasMN> listas { get; set; }
        public DbSet<DetalleListaMN> detalleLista { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlite("Data Source=sqliteEjercicioClaroV.db");


        }

    }





}
