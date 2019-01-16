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
    public class ApiCategoriaData : BaseData
    {
        public DataTable FoliosFotos(int idFolio, int idU, string mimeType)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap04_folioFoto_guarda");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            _comando.Parameters.AddWithValue("@mimeType", mimeType);
            _comando.Parameters.AddWithValue("@idUsuario", idU);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable ActasFotos(int idFolio, int idU, string mimeType)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap05_folioActa_guarda");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            _comando.Parameters.AddWithValue("@mimeType", mimeType);
            _comando.Parameters.AddWithValue("@idUsuario", idU);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable IncidenciasFotos(int idFolio, int idU, string mimeType, string observacion)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap06_folioIncidencias_guarda");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            _comando.Parameters.AddWithValue("@mimeType", mimeType);
            _comando.Parameters.AddWithValue("@idUsuario", idU);
            _comando.Parameters.AddWithValue("@Observaciones", observacion);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable ConfirmaSupervisado(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap07_ConfirmaSupervisado");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }
        public DataTable agregarActividadguardar(int idFolio, int idActividad, int iduCaptura)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap08_agregarActividad_guardar");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            _comando.Parameters.AddWithValue("@idActividad", idActividad);
            _comando.Parameters.AddWithValue("@iduCaptura", iduCaptura);
            return Configuracion.EjecutarComando(_comando);
        }
        public DataTable agregarActividadbuscar(int idMarca, int idTuberia, int idTraslado, string descripcion)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap08_agregarActividad_buscar");
            _comando.Parameters.AddWithValue("@idMarca", idMarca);
            _comando.Parameters.AddWithValue("@idTuberia", idTuberia);
            _comando.Parameters.AddWithValue("@idTraslado", idTraslado);
            _comando.Parameters.AddWithValue("@descripcion", descripcion);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}