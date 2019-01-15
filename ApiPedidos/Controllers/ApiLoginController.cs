using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiPedidos.Controllers
{
    public class ApiLoginController : ApiBaseController
    {
        ApiUsuarioModel Modelo = new ApiUsuarioModel();
        ApiUsuarioData Data = new ApiUsuarioData();

        [Route("api/ApiLogin/Login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] Login data)
        {
            var json = new Response();
            try
            {
                var dt = Data.UsuarioLogin(data);

                if (dt.Columns.Contains("codigo"))
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = dt.Rows[0]["Mensaje"].ToString()
                    };

                }
                else
                {
                    Modelo.Asignar(dt);

                    json = new Response
                    {
                        Success = true,
                        Mensaje = Modelo.Nombre,
                        Json = Modelo
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

        [Route("api/ApiLogin/Registro")]
        [HttpPost]
        public IHttpActionResult Registro([FromUri] StandardUri info,[FromBody] UsuarioModel data)
        {
            var json = new Response();
            var ModeloReg = new UsuarioModel();
            try
            {
                ModeloReg = data;
                info = info ?? new StandardUri();

                var ModeloSP = new EjecutarEntidad
                {
                    stored = "sp_Usuarios_Registro",
                    parametros = ModeloReg.ParametrosRegistro(),
                    guarda = 1
                };

                var dt = EjecutarSP(info, ModeloSP);

                if (dt.Success)
                {
                    var login = new Login
                    {
                        Usuario = data.Usuario,
                        Password = data.Password
                    };

                    var dt2 = Data.UsuarioLogin(login);

                    if (dt2.Rows.Count > 0)
                    {
                        Modelo.Asignar(dt2);

                        json = new Response
                        {
                            Success = true,
                            Mensaje = dt.Mensaje,
                            Json = Modelo
                        };
                    }

                }
                else
                {
                    json = new Response
                    {
                        Success = dt.Success,
                        Mensaje = dt.Mensaje
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

    }
}
