using Datos.Data;
using Datos.Models;
using Globalizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Yates.Controllers
{
    //[SessionControl]
    public class BaseController : Controller
    {
        public int idUsuario { get; } = System.Web.HttpContext.Current.Session["idUsuario"] != null ? (int)System.Web.HttpContext.Current.Session["idUsuario"] : 0;
        public int idPerfil { get; } = System.Web.HttpContext.Current.Session["idPerfil"] != null ? (int)System.Web.HttpContext.Current.Session["idPerfil"] : 0;
        public string idioma { get; } = System.Web.HttpContext.Current.Session["idioma"] != null ? System.Web.HttpContext.Current.Session["idioma"].ToString() : "es";

        public BaseData BaseData = new BaseData();

        public CombosData ComboData = new CombosData();
        public Labels labels = new Labels();

        public BaseController()
        {
            GenerarViewBag(null, null);
            try
            {
                labels.CambiarIdioma(idioma);
            }
            catch (Exception ex)
            {
                string msg = "";
                msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                msg = msg.Replace(System.Environment.NewLine, "");
                GenerarViewBag(msg, "error");
            }
        }

        public void GenerarViewBag(string mensaje, string tipo)
        {
            var current = System.Web.HttpContext.Current;

            if (mensaje != null && tipo != null)
            {
                ViewBag.mensaje = mensaje;
                ViewBag.tipo = tipo;
            }
            else if (current.Session["mensaje"] != null)
            {
                ViewBag.mensaje = current.Session["mensaje"].ToString();
                ViewBag.tipo = current.Session["tipo"].ToString();

                current.Session.Remove("mensaje");
                current.Session.Remove("tipo");
            }
        }

        public void MenuActualViewBag(int idMenu)
        {
            ViewBag.idMenu = idMenu;
        }

        public Resultado EjecutarSP(bool esJson, EjecutarEntidad Modelo)
        {
            var current = System.Web.HttpContext.Current;
            var dt = new DataTable();
            Resultado json = new Resultado();

            try
            {
                Modelo.idUsuario = idUsuario;
                Modelo.idioma = idioma;

                dt = BaseData.sc_ejecutar(Modelo);

                if (!esJson)
                {
                    current.Session["mensaje"] = dt.Rows[0]["mensaje"].ToString();
                    current.Session["tipo"] = "success";
                }

                json = new Resultado { Success = true, Id = (int)dt.Rows[0][0], Mensaje = dt.Rows[0]["mensaje"].ToString() };
            }
            catch (Exception ex)
            {
                string msg = "";

                msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                msg = msg.Replace(System.Environment.NewLine, "");

                if (!esJson)
                {
                    GenerarViewBag(msg, "error");
                }

                json = new Resultado { Success = false, Id = 0, Mensaje = msg };
            }

            return json;
        }

        public ActionResult ChangeCulture(string lang, string ReturnUrl)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);
            //var usuario = new LoginViewModel();
            //usuario.IdiomaSelected = lang;
            Session["Culture"] = lang;
            Session["idioma"] = lang;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture.DateTimeFormat = new DateTimeFormatInfo() { FullDateTimePattern = "dd/MM/yyyy HH:mm:ss", LongDatePattern = "dd/MM/yyyy", LongTimePattern = "HH:mm:ss", ShortDatePattern = "dd/MM/yyyy", ShortTimePattern = "HH:mm" };
            Thread.CurrentThread.CurrentUICulture.NumberFormat = new NumberFormatInfo() { CurrencyDecimalSeparator = ".", NumberDecimalSeparator = ".", CurrencyGroupSeparator = ",", NumberGroupSeparator = "," };

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public void GuardarArchivo(string NewFileName, string Path, HttpPostedFileBase File)
        {
            var basePath = System.IO.Path.Combine(Server.MapPath("~/Media/"), Path);

            File.SaveAs(System.IO.Path.Combine(basePath, NewFileName));
        }

        public void GuardarThumb(string NewFileName, string Path, HttpPostedFileBase File)
        {
            var basePath = System.IO.Path.Combine(Server.MapPath("~/Media/"), Path, NewFileName);
            WebImage img = new WebImage(File.InputStream);
            img.Resize(250, 250);
            img.Save(basePath);
        }

        public void BorrarArchivo(string NewFileName, string Path)
        {
            var basePath = System.IO.Path.Combine(Server.MapPath("~/Media/"), Path, NewFileName);

            System.IO.File.Delete(basePath);
        }

        public void BuscarArchivo(string FileName, int id, string Path, string FileExt)
        {
            object json = new object();

            string File = Url.Content("~") + "/Media/" + Path + "/" + FileName + FileExt;

            json = new { success = true, file = File };
        }

        private void CrearMenu()
        {
            /*
            var menuDb = BaseData.menu(idPerfil, idUsuario, idioma);

            var menuToBind = new List<MenuItem>();

            List<MenuItem> lista = new List<MenuItem>();
            foreach (var item in menuDb.Rows)
            {
                var row = item as DataRow;
                if (row != null)
                {
                    var entidad = new MenuItem();
                    entidad.Id = Convert.ToInt32(row["idmenu"]);
                    entidad.Descripcion = row["Menu"].ToString();
                    entidad.Action = row["ruta"].ToString();
                    entidad.Controller = row["metodo"].ToString();
                    entidad.Padre = Convert.ToInt32(row["padre"]);
                    entidad.EsLink = Convert.ToBoolean(row["esModulo"]);
                    lista.Add(entidad);
                }
            }


            var listaF = lista;
            Session["Menu"] = lista;
            var menuarr = Session["Menu"];
            */
        }

        //public JsonResult Estados(int id, string filtroEstado)
        //{
        //    var Estados = ComboData.ComboEntidades(0, id, idUsuario, idioma);

        //    if (!string.IsNullOrEmpty(filtroEstado))
        //    {
        //        Estados = Estados.Where(p => p.Texto.Contains(filtroEstado.ToUpper())).ToList();
        //    }

        //    return Json(Estados.Select(e => new { e.Id, e.Texto }), JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Ciudades(int id, string filtroCiudad)
        //{
        //    var Ciudades = ComboData.ComboCiudades(0, id, idUsuario, idioma);

        //    if (!string.IsNullOrEmpty(filtroCiudad))
        //    {
        //        Ciudades = Ciudades.Where(p => p.Texto.Contains(filtroCiudad.ToUpper())).ToList();
        //    }

        //    return Json(Ciudades.Select(e => new { e.Id, e.Texto }), JsonRequestBehavior.AllowGet);
        //}
    }
}