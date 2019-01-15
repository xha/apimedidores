using System;
using System.Collections.Generic;
using Datos.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class CombosData 
    {

        public  IList<Combo> folioBuscar(string folioOficial, int idUsuario, string claveZona)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap03_folioBuscar");
            _comando.Parameters.AddWithValue("@folioOficial", folioOficial);
            _comando.Parameters.AddWithValue("@claveZona ", claveZona);
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> ComboUnidades(int idUnidad, int idUsuario, string idioma)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_Unidades_combo");
            _comando.Parameters.AddWithValue("@idUnidad", idUnidad);
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            _comando.Parameters.AddWithValue("@Idioma", idioma);
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> ComboCategorias(int idUsuario, string idioma)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_Categorias_combo");
            _comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            _comando.Parameters.AddWithValue("@Idioma", idioma);
            return Configuracion.GetList(_comando);
        }

        public IList<Combo> ComboZonas(int idU)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap01_zona");
            return Configuracion.GetList(_comando);
        }

        public  IList<Combo> foliosCapturados(int idUsuario)
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
