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
    public class ApiUsuarioData: BaseData
    {
        public DataTable UsuarioLogin(Login Modelo)
        {
            SqlCommand _comando = Configuracion.CrearComando("st_ap01_autorizacion");
            _comando.Parameters.AddWithValue("@user", Modelo.Usuario);
            _comando.Parameters.AddWithValue("@Pass", Modelo.Password);
            _comando.Parameters.AddWithValue("@ubicacionGPS", Modelo.ubicacionGPS);
            _comando.Parameters.AddWithValue("@zona", Modelo.zona);
            return Configuracion.EjecutarComando(_comando);
        }

        public DataTable Usuarios(UsuarioModel Modelo, StandardUri User)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_Usuarios_Select");
            _comando.Parameters.AddWithValue("@idU", Modelo.IdUsuario);
            _comando.Parameters.AddWithValue("@esCliente", Modelo.EsCliente);
            _comando.Parameters.AddWithValue("@idPerfil", Modelo.IdPerfil);
            _comando.Parameters.AddWithValue("@idEmpresa", Modelo.IdEmpresa);
            _comando.Parameters.AddWithValue("@idUsuario", User.idU);
            _comando.Parameters.AddWithValue("@idioma", User.lang);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}
