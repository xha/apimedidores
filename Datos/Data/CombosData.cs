using System;
using System.Collections.Generic;
using Datos.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos.Data
{
    public class CombosData
    {

        public IList<Combo> folioBuscar(string folioOficial, int idUsuario, string claveZona)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap03_folioBuscar");
            _comando.Parameters.AddWithValue("@folioOficial", folioOficial);
            _comando.Parameters.AddWithValue("@claveZona ", claveZona);
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);

            return Configuracion.GetList(_comando);
        }

        public DataTable fotosListar(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_ap04_folioFoto_lista");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable actasListar(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_ap04_folioActa_lista");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable incidenciasListar(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_ap04_folioIncidencia_lista");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }

        public IList<Combo> Actividadtuberias()
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap08_agregarActividad_tuberias");
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> Actividadmarcas()
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap08_agregarActividad_marcas");
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> Actividadtraslados()
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap08_agregarActividad_traslados");
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> Combozonas()
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap01_zona");
            return Configuracion.GetList(_comando);
        }


        public DataTable CostoDelFolio(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap07_CostoDelFolio");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }



        public DataTable ActividadesConsultar(int idFolio)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap07_ActividadesConsultar");
            _comando.Parameters.AddWithValue("@idFolio", idFolio);
            return Configuracion.EjecutarComando(_comando);
        }

        public IList<Combo> foliosCapturados(int idUsuario)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap02_foliosCapturadosCuenta");
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> PendientesConsulta(int idUsuario)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap02_foliosPendientesConsulta");
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            return Configuracion.GetList(_comando);
        }

    }
}
