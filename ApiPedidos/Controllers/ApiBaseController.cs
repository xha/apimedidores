using Datos.Data;
using Datos.Models;
using Globalizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiPedidos.Controllers
{
    public class ApiBaseController : ApiController
    {
        public BaseData BaseData = new BaseData();
        public ApiBaseModel BaseModel = new ApiBaseModel();
        public CombosData ComboData = new CombosData();
        public Labels labels = new Labels();

        public Resultado EjecutarSP(StandardUri data, EjecutarEntidad Modelo)
        {
            var current = System.Web.HttpContext.Current;
            var dt = new DataTable();
            Resultado json = new Resultado();

            try
            {
                Modelo.idUsuario = data.idU;
                Modelo.idioma = data.lang;

                dt = BaseData.sc_ejecutar(Modelo);

                json = new Resultado { Success = true, Id = (int)dt.Rows[0][0], Mensaje = dt.Rows[0]["Mensaje"].ToString() };
            }
            catch (Exception ex)
            {
                string msg = "";

                msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                msg = msg.Replace(System.Environment.NewLine, "");

                json = new Resultado { Success = false, Id = 0, Mensaje = msg };
            }

            return json;
        }

        //-----------Combos
        [Route("api/ApiBase/Zonas")]
        [HttpGet]
        public IHttpActionResult Zonas([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.ComboZonas(data.idU);

                json = new Response
                {
                    Success = true,
                    Json = Combos
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/foliosCapturados")]
        [HttpGet]
        public IHttpActionResult foliosCapturados( [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.foliosCapturados(data.idU);

                json = new Response
                {
                    Success = true,
                    Json = Combos
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/PendientesConsulta")]
        [HttpGet]
        public IHttpActionResult PendientesConsulta([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.PendientesConsulta(data.idU);

                json = new Response
                {
                    Success = true,
                    Json = Combos
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/folioBuscar")]
        [HttpGet]
        public IHttpActionResult folioBuscar(string folioOficial, string claveZona, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.folioBuscar(folioOficial, data.idU, claveZona);

                json = new Response
                {
                    Success = true,
                    Json = Combos
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/Unidades")]
        [HttpGet]
        public IHttpActionResult Unidades(int id, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.ComboUnidades(id, data.idU, data.lang);

                json = new Response
                {
                    Success = true,
                    Json = Combos
                };

            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/Categorias")]
        [HttpGet]
        public IHttpActionResult Categorias([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.ComboCategorias(data.idU, data.lang);

                json = new Response
                {
                    Success = true,
                    Json = Combos
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