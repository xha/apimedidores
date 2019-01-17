using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ApiCategoriaModel
    {
        public ApiCategoriaModel()
        {
            Descripcion = "";
        }

        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public void Asignar(DataTable Data)
        {
            var item = Data.Rows[0];
            IdCategoria = (int)item["Id"];
            Descripcion = (string)item["Descripcion"];
            Habilitado = (bool)item["Habilitado"];
        }

        public List<ApiCategoriaModel> PrepararJson(DataTable Data)
        {
            var json = new List<ApiCategoriaModel>();
            foreach (DataRow item in Data.Rows)
            {
                json.Add(new ApiCategoriaModel
                {
                    IdCategoria = (int)item["Id"],
                    Descripcion = (string)item["Descripcion"],
                    Habilitado = (bool)item["Habilitado"],
                });
            }

            return json;
        }

        public string Parametros(StandardUri User)
        {
            string parametros = "";

            parametros += string.Concat(
                IdCategoria, ",'",
                Descripcion, "',",
                User.idU, ",",
                User.lang
            );

            return parametros;
        }
    }
}
