using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ApiBaseModel
    {
        public ApiBaseModel()
        {
            Response = new Response();
        }

        public Response Response { get; set; }
        public StandardUri StandardUri { get; set; }

        public void HttpResponse(bool success, string msg, int id, object Modelo)
        {
            Response.Success = success;
            Response.Mensaje = msg;
            Response.Id = 0;
            Response.Json = Modelo;
        }

        public string ParametrosGeneral(int id, StandardUri User)
        {
            string parametros = "";

            parametros = string.Concat(
                id, ",",
                User.idU, ",",
                "'", User.lang, "'"
            );

            return parametros;
        }
    }

    public class Response
    {
        public Response()
        {
            Mensaje = "";
            Json = new object();
        }

        public bool Success { get; set; }
        public string Mensaje { get; set; }
        public int Id { get; set; }
        public object Json { get; set; }
    }

    public class StandardUri
    {
        public StandardUri()
        {
            lang = "es";
        }

        public int idU { get; set; }
        public string lang { get; set; }
    }
}
