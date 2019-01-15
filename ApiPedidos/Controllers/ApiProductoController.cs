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
    public class ApiProductoController : ApiBaseController
    {
        ApiProductoModel Modelo = new ApiProductoModel();
        ApiProductoData Data = new ApiProductoData();

        [Route("api/ApiProducto/Get")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] ApiProductoModel data, [FromUri] StandardUri User)
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

                Modelo = data ?? new ApiProductoModel();
                var dt = Data.Productos(Modelo, User);

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

        [Route("api/ApiProducto/Post")]
        [HttpPost, HttpPatch]
        public IHttpActionResult Post([FromBody] ApiProductoModel data, [FromUri] StandardUri User)
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

                Modelo = data ?? new ApiProductoModel();

                var ModeloSP = new EjecutarEntidad
                {
                    stored = "sp_Productos_Guarda",
                    parametros = Modelo.Parametros(User),
                    guarda = Modelo.IdProducto == 0 ? 1 : 2
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

        [Route("api/ApiProducto/Put")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ApiProductoModel data, [FromUri] StandardUri User)
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
                    parametros = BaseModel.ParametrosGeneral(data.IdProducto, User),
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

        [Route("api/ApiProducto/ActualizaStock")]
        [HttpPut]
        public IHttpActionResult ActualizaStock([FromBody] ApiProductoModel data, [FromUri] StandardUri User)
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

                Modelo = data ?? new ApiProductoModel();

                var ModeloSP = new EjecutarEntidad
                {
                    stored = "sp_Productos_ActualizaStock",
                    parametros = Modelo.ParametrosStock(User),
                    guarda = 2
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
