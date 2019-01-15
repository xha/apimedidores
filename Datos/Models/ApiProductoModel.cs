using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ApiProductoModel
    {
        public ApiProductoModel()
        {
            Categoria = "";
            Codigo = "";
            Descripcion = "";
            Cantidad = 0;
            Precio = 0;
            CantidadMinima = 0;
            PrecioMoneda = "";
            Unidad = "";
        }
        
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdInventario { get; set; }
        public int IdUnidadCompra { get; set; }
        public int IdUnidadVenta { get; set; }
        public decimal Cantidad { get; set; }
        public string Stock { get; set; }
        public decimal Precio { get; set; }
        public decimal CantidadMinima { get; set; }
        public int IdMoneda { get; set; }
        public int IdEmpresa { get; set; }
        public string PrecioMoneda { get; set; }
        public string Unidad { get; set; }
        public bool Sumar { get; set; }

        public List<ApiProductoModel> PrepararJson(DataTable Data)
        {
            var json = new List<ApiProductoModel>();
            foreach (DataRow item in Data.Rows)
            {
                json.Add(new ApiProductoModel
                {
                    IdProducto = (int)item["Id"],
                    IdCategoria = (int)item["idCategoria"],
                    Categoria = (string)item["Categoria"],
                    Codigo = (string)item["Codigo"],
                    Descripcion = (string)item["Descripcion"],
                    IdInventario = (int)item["idInventario"],
                    IdUnidadCompra = (int)item["idUnidadCompra"],
                    IdUnidadVenta = (int)item["idUnidadVenta"],
                    Unidad = (string)item["Unidad"],
                    Cantidad = (decimal)item["Cantidad"],
                    Precio = (decimal)item["Precio"],
                    IdMoneda = (int)item["idMoneda"],
                    PrecioMoneda = (string)item["PrecioMoneda"],
                    Stock = (string)item["Stock"],
                    Habilitado = (bool)item["Habilitado"],
                });
            }

            return json;
        }

        public string Parametros(StandardUri User)
        {
            string parametros = "";

            parametros += string.Concat(
                IdProducto, ",",
                IdEmpresa, ",",
                IdCategoria, ",'",
                Codigo, "','",
                Descripcion, "',",
                IdUnidadVenta, ",",
                Cantidad, ",",
                IdMoneda, ",",
                Precio, ",",
                CantidadMinima, ",",
                User.idU, ",",
                User.lang
            );

            return parametros;
        }

        public string ParametrosStock(StandardUri User)
        {
            string parametros = "";

            parametros += string.Concat(
                IdInventario, ",",
                IdUnidadVenta, ",",
                Cantidad, ",",
                Sumar, ",",
                User.idU, ",",
                User.lang
            );

            return parametros;
        }
    }
}
