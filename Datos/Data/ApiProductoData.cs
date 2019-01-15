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
    public class ApiProductoData: BaseData
    {
        public DataTable Productos(ApiProductoModel Modelo, StandardUri User)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_Productos_Select");
            _comando.Parameters.AddWithValue("@idProducto", Modelo.IdProducto);
            _comando.Parameters.AddWithValue("@idEmpresa", Modelo.IdEmpresa);
            _comando.Parameters.AddWithValue("@idCategoria", Modelo.IdCategoria);
            _comando.Parameters.AddWithValue("@Codigo", Modelo.Codigo);
            _comando.Parameters.AddWithValue("@Descripcion", Modelo.Descripcion);
            _comando.Parameters.AddWithValue("@idUnidadVenta", Modelo.IdUnidadVenta);
            _comando.Parameters.AddWithValue("@idMoneda", Modelo.IdMoneda);
            _comando.Parameters.AddWithValue("@idUsuario", User.idU);
            _comando.Parameters.AddWithValue("@idioma", User.lang);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}
