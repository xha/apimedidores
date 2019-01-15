using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class GlobalizacionData
    {
        public static DataTable GetEtiquetas(string idioma)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_etiquetas");
            _comando.Parameters.AddWithValue("@Idioma", idioma);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}
