using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class UsuariosModel : BaseModel
    {
        public UsuariosModel()
        {
            Nombres = "";
            Apellidos = "";
            Telefono = "";
            Usuario = "";
            Password = "";
            Correo = "";
            Habilitado = true;

            PerfilesList = new List<Combo>();
            PersonasList = new List<Combo>();
            UsuariosGrid = new DataTable();
        }

        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Correo { get; set; }
        public int IdPerfil { get; set; }
        public bool Habilitado { get; set; }

        public int IdDireccion { get; set; }
        public int IdPais { get; set; }
        public int IdEstado { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string TelefonoLocal { get; set; }
        public string TelefonoMovil { get; set; }

        public int IdCuentaPaypal { get; set; }
        public string CuentaPaypal { get; set; }
        public string PasswordPaypal { get; set; }
        public bool ClientePaypal { get; set; }
        public bool EmpresaPaypal { get; set; }

        public bool EsPaypal { get; set; }
        public bool EsPassword { get; set; }
        public bool EsDireccion { get; set; }

        public IList<Combo> PerfilesList { get; set; }
        public IList<Combo> PersonasList { get; set; }
        public DataTable UsuariosGrid { get; set; }

        public string ParametrosGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                IdUsuario,",'",
                Nombres,"','",
                Apellidos,"','",
                Telefono,"','",
                Usuario,"','",
                Password,"','",
                Correo,"',",
                IdPerfil,",",
                Habilitado,",",
                idUsuario,",'",
                idioma,"'"
            );

            return parametros;
        }

        public string ParametrosMUGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                IdUsuario, ",'",
                Nombres, "','",
                Apellidos, "','",
                Telefono, "','",
                Usuario, "','",
                Correo, "',",
                idUsuario, ",'",
                idioma, "'"
            );

            return parametros;
        }

        public string ParametrosDCGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                IdDireccion, ",",
                IdUsuario, ",",
                IdCiudad, ",'",
                Direccion, "','",
                CodigoPostal, "','",
                TelefonoLocal, "','",
                TelefonoMovil, "',",
                idUsuario, ",'",
                idioma, "'"
            );

            return parametros;
        }

        public string ParametrosPGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                IdUsuario, ",'",
                Password, "',",
                idUsuario, ",'",
                idioma, "'"
            );

            return parametros;
        }

        public string ParametrosPPGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                IdCuentaPaypal, ",",
                IdUsuario, ",'",
                CuentaPaypal, "','",
                PasswordPaypal, "',",
                ClientePaypal ? 1 : 0, ",",
                !ClientePaypal ? 1 : 0, ",",
                idUsuario, ",'",
                idioma, "'"
            );

            return parametros;
        }

        public void AsignarById(DataTable Data)
        {
            var item = Data.Rows[0];
            IdUsuario = (int)item["Id"];
            Usuario = (string)item["Usuario"];
            Password = (string)item["Contrasena"];
            Correo = (string)item["Correo"];
            Telefono = (string)item["Telefono"];
            Nombres = (string)item["Nombres"];
            Apellidos = (string)item["Apellidos"];
            IdPerfil = (int)item["idPerfil"];

            IdDireccion = (int)item["idDireccionContacto"];
            IdPais = (int)item["idPais"];
            IdEstado = (int)item["idEstado"];
            IdCiudad = (int)item["idCiudad"];
            Direccion = (string)item["Direccion"];
            CodigoPostal = (string)item["CodigoPostal"];
            TelefonoLocal = (string)item["TelefonoLocal"];
            TelefonoMovil = (string)item["TelefonoMovil"];

            IdCuentaPaypal = (int)item["idCuentaPaypal"];
            CuentaPaypal = (string)item["CuentaPaypal"];
            PasswordPaypal = (string)item["PasswordPaypal"];
            ClientePaypal = (bool)item["ClientePaypal"];
            EmpresaPaypal = (bool)item["EmpresaPaypal"];

        }
    }
}
