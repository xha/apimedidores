using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPedidos.Controllers
{
    public class ApiUsuarioController : ApiBaseController
    {
        UsuarioModel Modelo = new UsuarioModel();
        ApiUsuarioData Data = new ApiUsuarioData();

        [Route("api/ApiUsuario/Get")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] UsuarioModel data, [FromUri] StandardUri User)
        {
            var json = new Response();
            try
            {
                var u = User ?? new StandardUri();

                if (u.idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                Modelo = data ?? new UsuarioModel();
                var dt = Data.Usuarios(Modelo, User);

                if (dt.Rows.Count > 0)
                {
                    json = new Response
                    {
                        Success = true,
                        Json = Modelo.PrepararJson(dt)
                    };
                }
                else
                {
                    json = new Response
                    {
                        Success = true,
                        Json = new List<object>()
                    };
                }
            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiUsuario/Post")]
        [HttpPost, HttpPatch]
        public IHttpActionResult Post([FromBody] UsuarioModel data, [FromUri] StandardUri User)
        {
            var json = new Response();
            try
            {
                var u = User ?? new StandardUri();

                if (u.idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                Modelo = data ?? new UsuarioModel();

                var ModeloSP = new EjecutarEntidad
                {
                    stored = "sp_Usuarios_Guarda",
                    parametros = Modelo.ParametrosGuarda(User),
                    guarda = Modelo.IdUsuario == 0 ? 1 : 2
                };

                var dt = EjecutarSP(User, ModeloSP);

                json = new Response
                {
                    Success = dt.Success,
                    Mensaje = dt.Mensaje
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiUsuario/Put")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] UsuarioModel data, [FromUri] StandardUri User)
        {
            var json = new Response();
            try
            {
                var u = User ?? new StandardUri();

                if (u.idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                var ModeloSP = new EjecutarEntidad
                {
                    stored = "sp_Productos_Delete",
                    parametros = BaseModel.ParametrosGeneral(data.IdUsuario, User),
                    guarda = 3
                };

                var dt = EjecutarSP(User, ModeloSP);

                json = new Response
                {
                    Success = dt.Success,
                    Mensaje = dt.Mensaje
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }


    }
}
