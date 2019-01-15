using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ApiUsuarioModel
    {
        public ApiUsuarioModel()
        {
            Usuario = "";
            Nombre = "";
            Telefono = "";
            Correo = "";
            Login = new Login();
            Perfil = new Perfiles();
            Empresa = new Empresa();
        }

        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdPerfil { get; set; }
        public Login Login { get; set; }
        public Perfiles Perfil { get; set; }
        public Empresa Empresa { get; set; }
        
        public void Asignar(DataTable Data)
        {
            var item = Data.Rows[0];
            Id = (int)item["idUsuario"];
            Usuario = (string)item["nombreUsu"];
           
        }
    }

    public class Login
    {
        public Login()
        {
            Usuario = "";
            Password = "";
            ubicacionGPS = "";
            zona = "";
        }

        public string Usuario { get; set; }
        public string Password { get; set; }
        public string ubicacionGPS { get; set; }
        public string zona { get; set; }
    }

    public class Perfiles
    {
        public bool Admin { get; set; }
        public bool Vendedor { get; set; }
        public bool Despachador { get; set; }
        public bool Cliente { get; set; }
    }
    public class Empresa
    {
        public Empresa()
        {
            Nombre = "";
            Direccion = "";
            Telefono = "";
            CoordLat = "";
            CoordLng = "";
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CoordLat { get; set; }
        public string CoordLng { get; set; }
    }


    public class UsuarioModel
    {
        public UsuarioModel()
        {
            Nombres = "";
            Apellidos = "";
            Correo = "";
            DNI = "";
            Usuario = "";
            Password = "";
            Direccion = "";
            Observaciones = "";
            Telefono = "";
            RazonSocial = "";
            Cuit = "";
            TelefonoEmpresa = "";
            CoordLat = "";
            CoordLng = "";
            Perfil = "";
            Pais = "";
            Estado = "";
            Ciudad = "";
        }

        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string DNI { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public bool EsEmpresa { get; set; }
        public string Observaciones { get; set; }
        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CoordLat { get; set; }
        public string CoordLng { get; set; }
        public bool Habilitado { get; set; }
        public bool EsCliente { get; set; }

        public List<UsuarioModel> PrepararJson(DataTable Data)
        {
            var json = new List<UsuarioModel>();
            foreach (DataRow item in Data.Rows)
            {
                var coord = item["Coordenadas"].ToString().Split('|');

                json.Add(new UsuarioModel
                {
                    IdUsuario = (int)item["Id"],
                    IdPerfil = (int)item["IdPerfil"],
                    Perfil = (string)item["Perfil"],
                    Usuario = (string)item["Usuario"],
                    Password = (string)item["Password"],
                    Correo = (string)item["Correo"],
                    Nombres = (string)item["Nombres"],
                    Apellidos = (string)item["Apellidos"],
                    Telefono = (string)item["Telefono"],
                    DNI = (string)item["DNI"],
                    EsEmpresa = (bool)item["esEmpresa"],
                    RazonSocial = (string)item["RazonSocial"],
                    TelefonoEmpresa = (string)item["TelefonoEmpresa"],
                    Cuit = (string)item["Cuit"],
                    IdPais = (int)item["IdPais"],
                    Pais = (string)item["Pais"],
                    IdEstado = (int)item["IdEntidad"],
                    Estado = (string)item["Estado"],
                    IdCiudad = (int)item["IdCiudad"],
                    Ciudad = (string)item["Ciudad"],
                    Direccion = (string)item["Direccion"],
                    Observaciones = (string)item["Observaciones"],
                    Habilitado = (bool)item["Habilitado"],
                    CoordLat = coord[0],
                    CoordLng = coord[0]
                });
            }

            return json;
        }

        public string ParametrosRegistro()
        {
            string parametros = "";

            parametros += string.Concat(
                "'",
                Nombres, "','",
                Apellidos, "','",
                DNI, "','",
                Usuario, "','",
                Password, "','",
                Correo, "','",
                Telefono, "',",
                EsEmpresa, ",'",
                RazonSocial, "','",
                Cuit, "','",
                Telefono, "','",
                Observaciones, "',",
                IdCiudad, ",'",
                Direccion, "','",
                CoordLat, "','",
                CoordLng, "'"
            );

            return parametros;
        }

        public string ParametrosGuarda(StandardUri User)
        {
            string parametros = "";

            parametros += string.Concat(
                IdUsuario, ",'",
                Nombres, "','",
                Apellidos, "','",
                DNI, "',",
                IdPerfil, ",'",
                Usuario, "','",
                Password, "','",
                Correo, "','",
                Telefono, "',",
                IdEmpresa, ",",
                EsEmpresa, ",'",
                RazonSocial, "','",
                Cuit, "','",
                TelefonoEmpresa, "','",
                Observaciones, "',",
                IdCiudad, ",'",
                Direccion, "','",
                CoordLat, "','",
                CoordLng, "',",
                User.idU, ",'",
                User.lang, "'"
            );

            return parametros;
        }

        public void Asignar(DataTable Data)
        {
            var item = Data.Rows[0];
            IdUsuario = (int)item["Id"];
            IdPerfil = (int)item["IdPerfil"];
            Perfil = (string)item["Perfil"];
            Usuario = (string)item["Usuario"];
            Password = (string)item["Password"];
            Correo = (string)item["Correo"];
            Nombres = (string)item["Nombres"];
            Apellidos = (string)item["Apellidos"];
            Telefono = (string)item["Telefono"];
            DNI = (string)item["DNI"];
            EsEmpresa = (bool)item["esEmpresa"];
            RazonSocial = (string)item["RazonSocial"];
            TelefonoEmpresa = (string)item["TelefonoEmpresa"];
            Cuit = (string)item["Cuit"];
            IdPais = (int)item["IdPais"];
            Pais = (string)item["Pais"];
            IdEstado = (int)item["IdEntidad"];
            Estado = (string)item["Estado"];
            IdCiudad = (int)item["IdCiudad"];
            Ciudad = (string)item["Ciudad"];
            Direccion = (string)item["Direccion"];
            Observaciones = (string)item["Observaciones"];
            Habilitado = (bool)item["Habilitado"];

            var coord = item["Coordenadas"].ToString().Split('|');

            CoordLat = coord[0];
            CoordLng = coord[0];
        }
    }
}
