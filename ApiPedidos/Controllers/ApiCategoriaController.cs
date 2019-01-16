using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace ApiPedidos.Controllers
{
    public class ApiCategoriaController : ApiBaseController
    {
        ApiCategoriaModel Modelo = new ApiCategoriaModel();
        ApiCategoriaData Data = new ApiCategoriaData();


        [Route("api/ApiFolio/Post")]
        [HttpPost, HttpPatch]
        [AllowAnonymous]
        public IHttpActionResult Post(int idFolio, int idU)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var json = new Response();
            try
            {

                if (idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }


                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var ext1 = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.') + 1);
                        var extension = ext.ToLower();
                        var exten = ext1.ToLower();

                        var dt = Data.FoliosFotos(idFolio, idU, exten);

                        string name = dt.Rows[0]["idFoto"].ToString();

                        json = new Response
                        {
                            Success = true,
                            Mensaje = "Foto Guardada correctamente"
                        };


                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 5 mb.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else
                        {


                            var filePath = HttpContext.Current.Server.MapPath("~/Fotos/folioFotos/" + name + "." + exten);

                            postedFile.SaveAs(filePath);

                        }
                    }
                }



                //var dt = EjecutarSP(User, ModeloSP);


            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiFolio/PostActa")]
        [HttpPost, HttpPatch]
        [AllowAnonymous]
        public IHttpActionResult PostActa(int idFolio, int idU)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var json = new Response();
            try
            {

                if (idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }


                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var ext1 = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.') + 1);
                        var extension = ext.ToLower();
                        var exten = ext1.ToLower();

                        var dt = Data.ActasFotos(idFolio, idU, exten);

                        string name = dt.Rows[0]["idFoto"].ToString();

                        json = new Response
                        {
                            Success = true,
                            Mensaje = "Foto Guardada correctamente"
                        };


                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 5 mb.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else
                        {


                            var filePath = HttpContext.Current.Server.MapPath("~/Fotos/folioActas/" + name + "." + exten);

                            postedFile.SaveAs(filePath);

                        }
                    }
                }



                //var dt = EjecutarSP(User, ModeloSP);


            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiFolio/PostIncidencia")]
        [HttpPost, HttpPatch]
        [AllowAnonymous]
        public IHttpActionResult PostIncidencia(int idFolio, int idU, string observacion)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var json = new Response();
            try
            {

                if (idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }


                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var ext1 = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.') + 1);
                        var extension = ext.ToLower();
                        var exten = ext1.ToLower();

                        var dt = Data.IncidenciasFotos(idFolio, idU, exten, observacion);

                        string name = dt.Rows[0]["idFoto"].ToString();

                        json = new Response
                        {
                            Success = true,
                            Mensaje = "Foto Guardada correctamente"
                        };


                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 5 mb.");

                            dict.Add("error", message);
                            json = new Response { Success = false, Id = 0, Mensaje = message };
                        }
                        else
                        {


                            var filePath = HttpContext.Current.Server.MapPath("~/Fotos/folioIncidencias/" + name + "." + exten);

                            postedFile.SaveAs(filePath);

                        }
                    }
                }



                //var dt = EjecutarSP(User, ModeloSP);


            }
            catch (Exception ex)
            {
                var msg = (ex.InnerException != null ? ex.InnerException.Message : ex.Message).Replace(System.Environment.NewLine, "");

                json = new Response { Success = false, Id = 0, Mensaje = msg };
            }

            return Ok(json);
        }

        [Route("api/ApiBase/CostoDelFolio")]
        [HttpGet]
        public IHttpActionResult CostoDelFolio(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.CostoDelFolio(idFolio);

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


        [Route("api/ApiBase/ActividadesConsultar")]
        [HttpGet]
        public IHttpActionResult ActividadesConsultar(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = ComboData.ActividadesConsultar(idFolio);

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

        [Route("api/ConfirmaSupervisado/Post")]
        [HttpPost]
        public IHttpActionResult ConfirmaSupervisado()
        {
            var httpRequest = HttpContext.Current.Request;
            int idFolio = Convert.ToInt32(httpRequest.Form["idFolio"]);
            int idU = Convert.ToInt32(httpRequest.Form["idU"]);
            var json = new Response();
            try
            {


                if (idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                var dt = Data.ConfirmaSupervisado(idFolio);

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


                    json = new Response
                    {
                        Success = true,
                        Json = "Registro actualizado correctamente"
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

        [Route("api/agregarActividadbuscar/Get")]
        [HttpGet]
        public IHttpActionResult agregarActividadbuscar()
        {
            var httpRequest = HttpContext.Current.Request;
            string descripcion = "";
            int idMarca = string.IsNullOrWhiteSpace(httpRequest["idMarca"]) ? Convert.ToInt32(0) : Convert.ToInt32(httpRequest["idMarca"]);
            int idTuberia = string.IsNullOrWhiteSpace(httpRequest["idTuberia"]) ? Convert.ToInt32(0) : Convert.ToInt32(httpRequest["idTuberia"]);
            int idTraslado = string.IsNullOrWhiteSpace(httpRequest["idTraslado"]) ? Convert.ToInt32(0) : Convert.ToInt32(httpRequest["idTraslado"]);
            if (httpRequest["descripcion"] != null)
            {
                descripcion = httpRequest["descripcion"].ToString();
            }

            int idU = Convert.ToInt32(httpRequest["idU"]);
            var json = new Response();
            try
            {


                if (idU == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                var dt = Data.agregarActividadbuscar(idMarca, idTuberia, idTraslado, descripcion);

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


                    json = new Response
                    {
                        Success = true,
                        Json = dt
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


        [Route("api/agregarActividadguardar/Post")]
        [HttpPost]
        public IHttpActionResult agregarActividadguardar()
        {
            var httpRequest = HttpContext.Current.Request;
            int idFolio = Convert.ToInt32(httpRequest.Form["idFolio"]);
            int idActividad = Convert.ToInt32(httpRequest.Form["idActividad"]);
            int idU = Convert.ToInt32(httpRequest.Form["idU"]);
            var json = new Response();
            try
            {


                if (idU == 0 || idFolio == 0)
                {
                    json = new Response
                    {
                        Success = false,
                        Mensaje = "No esta autoriado a utilizar este Recurso"
                    };
                    return Ok(json);
                }

                var dt = Data.agregarActividadguardar(idFolio, idActividad, idU);

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


                    json = new Response
                    {
                        Success = true,
                        Json = "Registro actualizado correctamente"
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
