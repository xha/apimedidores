﻿using Datos.Data;
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

        [Route("api/ApiBase/FotosListar")]
        [HttpGet]
        public IHttpActionResult FotosListar(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.FotosListar(idFolio);

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

        [Route("api/ApiBase/ActasListar")]
        [HttpGet]
        public IHttpActionResult ActasListar(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.ActasListar(idFolio);

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

        [Route("api/ApiBase/IncidenciasListar")]
        [HttpGet]
        public IHttpActionResult IncidenciasListar(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.IncidenciasListar(idFolio);

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

        //-----------Combos
        [Route("api/ApiBase/Zonas")]
        [HttpGet]
        public IHttpActionResult Zonas([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.Combozonas();

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
        public IHttpActionResult Estados([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.FoliosCapturados(data.idU);

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
        public IHttpActionResult Ciudades([FromUri] StandardUri data)
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

        [Route("api/ApiBase/FolioBuscar")]
        [HttpGet]
        public IHttpActionResult FolioBuscar(string folioOficial, string claveZona, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.FolioBuscar(folioOficial, data.idU, claveZona);

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

        [Route("api/ApiBase/Actividadtuberias")]
        [HttpGet]
        public IHttpActionResult Unidades([FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.Actividadtuberias();

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

        [Route("api/ApiBase/Actividadmarcas")]
        [HttpGet]
        public IHttpActionResult Categorias()
        {
            var json = new Response();

            try
            {
                var Combos = ComboData.Actividadmarcas();

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


        [Route("api/ApiBase/Actividadtraslados")]
        [HttpGet]
        public IHttpActionResult Actividadtraslados()
        {
            var json = new Response();

            try
            {
                var Combos = ComboData.Actividadtraslados();

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
