using Datos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class ApiCategoriaData: BaseData
    {
        public DataTable FoliosFotos(int idFolio, int idU, string mimeType)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap04_folioFoto_guarda");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            _comando.Parameters.AddWithValue("@mimeType", mimeType);
            _comando.Parameters.AddWithValue("@idUsuario", idU);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable CostoDelProducto(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap07_CostoDelFolio");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}
