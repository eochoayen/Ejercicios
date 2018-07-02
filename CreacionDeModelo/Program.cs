using ModeloDatosAcceso.ModeloNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CreacionDeModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeloEjercicioClaroV modelo = new ModeloEjercicioClaroV();
            modelo.Database.Migrate();
        }
    }
}
