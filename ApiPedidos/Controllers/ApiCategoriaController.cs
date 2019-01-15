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

        [Route("api/ApiFolio/CostoDelProducto")]
        [HttpGet, HttpPost]
        public IHttpActionResult CostoDelProducto(int idFolio, [FromUri] StandardUri data)
        {
            var json = new Response();
            data = data ?? new StandardUri();
            try
            {
                var Combos = Data.CostoDelProducto(idFolio);

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


                            var filePath = HttpContext.Current.Server.MapPath("~/Fotos/FolioFotos/" + name +"."+ exten);

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

        [Route("api/ApiCategoria/Put")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ApiCategoriaModel data, [FromUri] StandardUri User)
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
                    stored = "sp_Categorias_Delete",
                    parametros = BaseModel.ParametrosGeneral(data.IdCategoria, User),
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
